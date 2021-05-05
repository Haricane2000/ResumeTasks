package page;
import model.Item;
import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.support.ui.ExpectedConditions;
import org.openqa.selenium.support.ui.WebDriverWait;
import util.Resolver;

import java.util.ArrayList;
import java.util.List;

public class GucciBagPage {

    private WebDriver driver;
    private final By itemColorLocator =By.xpath("//span[@data-auto-id=\'cart-line-item-attribute-color\' ]");
    private final By itemSizeLocator =By.xpath("//span[@data-auto-id=\"cart-line-item-attribute-size\" ]");
    private final By itemNameLocator =By.xpath("//span[@data-auto-id=\"glass-cart-line-item-name\" ]");
    private final By itemPriceLocator =By.xpath("//div[@data-auto-id=\"glass-cart-line-item-price\" ]");
    private final By itemAmountLocator =By.xpath("//span[@class=\"gl-dropdown-custom__select-label-text\" ]");
    private final By removeFromBagLocator = By.xpath("//button[@data-auto-id =\"glass-cart-line-item-delete\" ]");
    private final By emptyBagLocator = By.xpath("//h3[@data-auto-id =\"glass-cart-empty-title\" ]");
    private final By deliveryValueLocator = By.xpath("//span[@data-auto-id=\"glass-cart-summary-delivery-value\"]");
    private final By couponFieldLocator = By.xpath("//input[@class = \"gl-input__field\"]");
    private final By applyCouponLocator = By.xpath("//button[@type=\"submit\"]");
    private final By originalPriceLocator = By.xpath("//div[@data-auto-id = \"glass-cart-product-total\"]/span[2]");
    private final By newPriceLocator = By.xpath("//span[@data-auto-id = \"glass-cart-summary-product-value\"]");
    private final By checkoutBtnLocator = By.xpath("//button[@data-auto-id = \"glass-checkout-button-bottom\"]");

    public GucciBagPage(WebDriver driver){
        this.driver = driver;
    }

    public GucciBagPage removeFromBag(){
        WebElement removeFromBagBtn = new WebDriverWait(driver,10)
                .until(ExpectedConditions.presenceOfElementLocated(removeFromBagLocator));
        removeFromBagBtn.click();
        return this;
    }

    public String getBagAmountText(){
        return new WebDriverWait(driver,10)
                .until(ExpectedConditions.presenceOfElementLocated(emptyBagLocator)).getText();
    }

    public Item getBagItemsInfo(){
        String itemName = new WebDriverWait(driver, 10)
                .until(ExpectedConditions.presenceOfElementLocated(itemNameLocator)).getText();
        String itemPrice = new WebDriverWait(driver, 10)
                .until(ExpectedConditions.presenceOfElementLocated(itemPriceLocator)).getText();
        String itemColor = new WebDriverWait(driver, 10)
                .until(ExpectedConditions.presenceOfElementLocated(itemColorLocator)).getText();
        String itemSize = new WebDriverWait(driver, 10)
                .until(ExpectedConditions.presenceOfElementLocated(itemSizeLocator)).getText();
        String itemAmount = new WebDriverWait(driver, 10)
                .until(ExpectedConditions.presenceOfElementLocated(itemAmountLocator)).getText();
        return new Item(itemName,itemColor,itemSize,itemPrice, itemAmount);
    }

    public String getDeliveryValue(){
        WebElement deliveryValue = new WebDriverWait(driver,10)
                .until(ExpectedConditions.presenceOfElementLocated(deliveryValueLocator));
        return deliveryValue.getText();
    }

    public GucciBagPage applyCoupon(String coupon){
        WebElement couponInputField = new WebDriverWait(driver,10)
                .until(ExpectedConditions.presenceOfElementLocated(couponFieldLocator));
        couponInputField.sendKeys(coupon);
        WebElement applyCouponBtn = new WebDriverWait(driver,20)
                .until(ExpectedConditions.presenceOfElementLocated(applyCouponLocator));
        applyCouponBtn.click();
        return this;
    }

    public List<Double> getOriginalAndTotalPrice(){
        List<WebElement> webElements = new ArrayList<>();
        webElements.add(new WebDriverWait(driver,20)
                .until(ExpectedConditions.presenceOfElementLocated(originalPriceLocator)));
        webElements.add(new WebDriverWait(driver,20)
                .until(ExpectedConditions.presenceOfElementLocated(newPriceLocator)));
        List<Double> priceList = Resolver.getPriceList(webElements, "Double");
        return priceList;
    }

    public GucciCheckoutPage openCheckoutPage(){
        WebElement checkoutBtn = new WebDriverWait(driver,10)
                .until(ExpectedConditions.elementToBeClickable(checkoutBtnLocator));
        checkoutBtn.click();
        return new GucciCheckoutPage(driver);
    }
}
