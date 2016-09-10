using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using PriceCompareEntities;

namespace PriceCompareControl.DataProvider
{
    internal class XmlsDataAccessor
    {
        internal static IDictionary<int, MapItem> ReadMapItems()
        {
            var i = 1;
            var path = new StreamReader(@"..\..\..\xmls\map.xml");
            var document = XDocument.Load(path);
            path.Dispose();

            var items = document.Element("Items");
            return (from item in items?.Descendants("Item")
                select new MapItem
                {
                    Id = i++,
                    ItemName = item.Element("ItemName")?.Value,
                    UnitQty = item.Element("UnitQty")?.Value,
                    IsGlobalCode = item.Element("GlobalCode")?.Value == "1",
                    BisWeighted = item.Element("BisWeighted")?.Value == "1",
                    GlobalItemCode = item.Element("ItemCode")?.Value,
                    ItemCodeByChains = GetCodeByChain(item.Element("Chains"))
                }).ToDictionary(x => x.Id);
        }

        private static IDictionary<string, string> GetCodeByChain(XContainer chains)
        {
            return chains?.Elements("Chain")
                .ToDictionary(chain => chain.Element("ChainId")?.Value,
                    chain => chain.Element("ItemCode")?.Value);
        }

        internal static IEnumerable<StoreItem> GetItem(string fileName, string itemCode)
        {
            var path = new StreamReader(fileName);
            var document = XDocument.Load(path);
            path.Dispose();
            var storeInfo = document.Element("Prices");
            var storeId = storeInfo?.Element("StoreID")?.Value;
            var subChainId = storeInfo?.Element("SubChainID")?.Value;
            var chainId = storeInfo?.Element("ChainID")?.Value;

            return from product in document.Descendants("Product")
                where product.Element("ItemCode")?.Value == itemCode
                let xElement = product.Element("ItemPrice")
                where xElement != null
                select new StoreItem
                {
                    ItemName = product.Element("ItemName")?.Value,
                    UnitQty = product.Element("UnitQty")?.Value,
                    Price = double.Parse(xElement.Value),
                    ChainId = chainId,
                    SubChainId = subChainId,
                    StoreId = storeId
                };
        }

        internal static IEnumerable<Store> GetStoreInfo(string chainDirectory, string storeId)
        {
            var path = new StreamReader($@"{chainDirectory}\Stores.xml");
            var document = XDocument.Load(path);
            path.Dispose();

            return from branch in document.Descendants("Branch")
                where branch.Element("StoreID")?.Value == storeId
                select new Store
                {
                    ChainId = branch.Element("ChainID")?.Value,
                    SubChainId = branch.Element("SubChainID")?.Value,
                    StoreId = branch.Element("StoreID")?.Value,
                    StoreType = branch.Element("StoreType")?.Value,
                    ChainName = branch.Element("ChainName")?.Value,
                    SubChainName = branch.Element("SubChainName")?.Value,
                    StoreName = branch.Element("StoreName")?.Value,
                    Address = branch.Element("Address")?.Value,
                    City = branch.Element("City")?.Value
                };
        }

        internal static void AddUserShoppingList(string userName, List<MapItem> itemsList)
        {
            var shoppingList = new XElement("ShoppingList");
            foreach (var item in itemsList)
            {
                shoppingList.Add(
                    new XElement(
                        "Item",
                        new XAttribute("ItemName", item.ItemName),
                        new XAttribute("UnitQty", item.UnitQty),
                        new XAttribute("Qty", item.Qty)
                        ));
            }

            var document = XDocument.Load(@"..\..\..\xmls\users.xml");
            foreach (var user in document.Elements("Users").Elements("User")
                .Where(user => user.Attribute("userName").Value == userName))
            {
                user.Element("ShoppingLists")?.Add(shoppingList);
            }
            document.Save(@"..\..\..\xmls\users.xml");
        }

        internal static IEnumerable<IEnumerable<ShoppingListItem>> GetAllShoppingList(string userName)
        {
            var document = XDocument.Load(@"..\..\..\xmls\users.xml");
            var users = document.Element("Users");
            var userShoppingLists = new List<List<ShoppingListItem>>();
            var xElements = users?.Descendants("User");
            if (xElements != null)
                userShoppingLists.AddRange(from user in xElements
                    where user.Attribute("userName").Value == userName
                    select user.Element("ShoppingLists")
                    into shoppingLists
                    from shoppingList in shoppingLists?.Descendants("ShoppingList")
                    select shoppingList.Descendants("Item").Select(item => new ShoppingListItem
                    {
                        ItemName = item.Attribute("ItemName").Value,
                        UnitQty = item.Attribute("UnitQty").Value,
                        Qty = item.Attribute("Qty").Value
                    }).ToList());
            return userShoppingLists;
        }
    }
}