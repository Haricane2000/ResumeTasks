package test;

import model.User;
import org.openqa.selenium.WebElement;
import org.testng.Assert;
import org.testng.annotations.Test;
import page.GucciProductPage;
import service.UserCreator;

import java.util.List;

import static org.hamcrest.MatcherAssert.assertThat;
import static org.hamcrest.Matchers.*;
import static org.hamcrest.Matchers.empty;

public class OrderTest extends CommonConditions {

    @Test
    public void applyCouponTest(){
        List<Double> originalAndNewPrice = new GucciProductPage(driver, "https://www.gucci.com/us/en/pr/men/ready-to-wear-for-men/outerwear-for-men/coats-for-men/gg-stripe-wool-coat-with-gucci-label-p-639261Z8AMH2668")
                .openPage()
                .selectItemSize("M")
                .addItemsToBag()
                .openBagPage()
                .applyCoupon("ADPRHS18")
                .getOriginalAndTotalPrice();
        assertThat(originalAndNewPrice.get(0), greaterThan(originalAndNewPrice.get(1)));
    }

    @Test
    public void freeDeliveryTest() {
        String expectedDeliveryValue = "FREE";
        String deliveryValue = new GucciProductPage(driver,"https://www.gucci.com/us/en/pr/men/ready-to-wear-for-men/outerwear-for-men/coats-for-men/gg-stripe-wool-coat-with-gucci-label-p-639261Z8AMH2668")
                .openPage()
                .selectItemSize("M")
                .addItemsToBag()
                .closeModal()
                .addItemsToBag()
                .openBagPage()
                .getDeliveryValue();
        assertThat(deliveryValue, equalTo(expectedDeliveryValue));
    }

    @Test
    public void wrongDeliveryCredentialsTest(){
        User user = UserCreator.withIncorrectAddress();
        List<WebElement> credentialsErrorsList = new GucciProductPage(driver,"https://www.gucci.com/us/en/pr/men/ready-to-wear-for-men/outerwear-for-men/coats-for-men/gg-stripe-wool-coat-with-gucci-label-p-639261Z8AMH2668")
                .openPage()
                .selectItemSize("M")
                .addItemsToBag()
                .openBagPage()
                .openCheckoutPage()
                .enterCredentials(user)
                .getAddressMessage();
        Assert.assertTrue(credentialsErrorsList.size() >0);
        assertThat(credentialsErrorsList, not(empty()));
    }

}
