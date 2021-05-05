package test;

import model.Item;
import org.testng.annotations.Test;
import page.GucciProductPage;
import service.ProductCreator;

import static org.hamcrest.MatcherAssert.assertThat;
import static org.hamcrest.Matchers.equalTo;

public class WishlistTest extends CommonConditions {

    @Test
    public void addToWishlistTest() {
        Item expectedItem = ProductCreator.withCredentialsFromPropertyForWishlist("first");
        Item wishlistItem = new GucciProductPage(driver,"https://www.gucci.com/us/en/pr/men/ready-to-wear-for-men/outerwear-for-men/coats-for-men/ken-scott-print-velvet-coat-p-643978Z8AL61067")
                .openPage()
                .addItemToWishlist()
                .openWishlistPage()
                .getWishlistResult();
        assertThat(wishlistItem, equalTo(expectedItem));
    }
}
