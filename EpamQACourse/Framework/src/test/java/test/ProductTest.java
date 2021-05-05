package test;

import org.testng.annotations.Test;
import page.GucciCatalogPage;
import page.GucciProductPage;

import java.util.List;

import static org.hamcrest.MatcherAssert.assertThat;
import static org.hamcrest.Matchers.*;

public class ProductTest extends CommonConditions {

    @Test
    public void colorFilterTest(){
        String expectedColor = "Purple";
        String selectedItemColor = new GucciCatalogPage(driver,"https://www.gucci.com/us/en/ca/men/ready-to-wear-for-men/outerwear-for-men-c-men-readytowear-outerwear")
                .openPage()
                .applyColorFilter()
                .openItemWithFilter()
                .getItemColor();
        assertThat(selectedItemColor, containsString(expectedColor));
    }

    @Test
    public void sortByPriceTest(){
        List<Integer> itemsPriceList = new GucciCatalogPage(driver,"https://www.gucci.com/us/en/ca/men/ready-to-wear-for-men/outerwear-for-men-c-men-readytowear-outerwear")
                .openPage()
                .sortByPrice()
                .getItemsPriceList();
        assertThat(itemsPriceList.get(0), greaterThanOrEqualTo(itemsPriceList.get(1)));
    }

    @Test
    public void addItemOutOfStockTest(){
        String expectedMessage = "Selected size is no longer available";
        String outOfStockMessage = new GucciProductPage(driver,"https://www.gucci.com/us/en/pr/men/ready-to-wear-for-men/outerwear-for-men/coats-for-men/ken-scott-print-velvet-coat-p-643978Z8AL61067")
                .openPage()
                .selectItemSize("M 11.5 / W 12.5")
                .addItemsToBag()
                .closeModal()
                .addItemsToBag()
                .closeModal()
                .addItemsToBag()
                .getOutOfStockMessage();
        assertThat(outOfStockMessage, equalTo(expectedMessage));
    }

    @Test
    public void addToBagWithoutSize(){
        String expectedMessage = "Please select your size";
        String noSizeSelectedText = new GucciProductPage(driver,"https://www.gucci.com/us/en/pr/men/ready-to-wear-for-men/outerwear-for-men/coats-for-men/ken-scott-print-velvet-coat-p-643978Z8AL61067")
                .openPage()
                .addItemsToBag()
                .getNoSizeSelectedMessage();
        assertThat(noSizeSelectedText, equalTo(expectedMessage));
    }
}
