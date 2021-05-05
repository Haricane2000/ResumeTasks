package service;

import model.Item;
import static util.Resolver.resolveTemplate;

public class ProductCreator {

    public static final String NAME = "testdata.item.%s.name";
    public static final String COLOR = "testdata.item.%s.color";
    public static final String SIZE = "testdata.item.%s.size";
    public static final String PRICE = "testdata.item.%s.price";
    public static final String AMOUNT = "testdata.item.%s.amount";

    public static Item withCredentialsFromPropertyForWishlist(String orderNumber){

        String itemName = resolveTemplate(NAME, orderNumber);
        String itemPrice = resolveTemplate(PRICE, orderNumber);
        String itemAmount = resolveTemplate(AMOUNT, orderNumber);
        return new Item(TestDataReader.getTestData(itemName), null, null, TestDataReader.getTestData(itemPrice), TestDataReader.getTestData(itemAmount));
    }

    public static Item withCredentialsFromPropertyForBag(String orderNumber){

        String itemName = resolveTemplate(NAME, orderNumber);
        String itemColor = resolveTemplate(COLOR, orderNumber);
        String itemSize = resolveTemplate(SIZE, orderNumber);
        String itemPrice = resolveTemplate(PRICE, orderNumber);
        String itemAmount = resolveTemplate(AMOUNT, orderNumber);
        return new Item(TestDataReader.getTestData(itemName), TestDataReader.getTestData(itemColor), TestDataReader.getTestData(itemSize), TestDataReader.getTestData(itemPrice), TestDataReader.getTestData(itemAmount));
    }

}
