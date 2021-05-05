package test;

import model.Item;
import org.testng.annotations.Test;
import page.GucciProductPage;
import service.ProductCreator;

import static org.hamcrest.MatcherAssert.assertThat;
import static org.hamcrest.Matchers.equalTo;

public class BagTest extends CommonConditions {

    @Test
    public void removeFromBagTest(){
        String expectedMessage = "YOUR BAG IS EMPTY";
        String emptyBagText = new GucciProductPage(driver,"https://www.gucci.com/us/en/pr/men/ready-to-wear-for-men/outerwear-for-men/coats-for-men/check-wool-coat-with-gucci-label-p-643805ZAC1I9549")
                .openPage()
                .selectItemSize("M")
                .addItemsToBag()
                .openBagPage()
                .removeFromBag()
                .getBagAmountText();
        assertThat(emptyBagText, equalTo(expectedMessage));
    }

    @Test
    public void addMultipleItemsToBag(){
        Item expectedItemInfo = ProductCreator.withCredentialsFromPropertyForBag("second");
        Item bagItemInfo = new GucciProductPage(driver,"https://www.gucci.com/us/en/pr/men/ready-to-wear-for-men/outerwear-for-men/coats-for-men/check-wool-coat-with-gucci-label-p-643805ZAC1I9549")
                .openPage()
                .selectItemSize("M")
                .addItemsToBag()
                .closeModal()
                .addItemsToBag()
                .openBagPage()
                .getBagItemsInfo();
        assertThat(bagItemInfo, equalTo(expectedItemInfo));
    }
}
