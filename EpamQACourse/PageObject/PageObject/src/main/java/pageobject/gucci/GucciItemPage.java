package pageobject.gucci;

import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.interactions.Actions;
import org.openqa.selenium.support.FindBy;
import org.openqa.selenium.support.ui.ExpectedConditions;
import org.openqa.selenium.support.ui.WebDriverWait;
import pageobject.Page;

public class GucciItemPage extends Page {

    private final String PAGE_URL = "https://www.gucci.com/pl/en_gb/pr/men/ready-to-wear-for-men/coats-for-men/coats-for-men/ken-scott-print-velvet-coat-p-643978Z8AL61067";

    @FindBy(xpath = "//*[@id='product-detail-add-to-shopping-bag-form']/div/button")
    private WebElement addToCartButton;
    @FindBy(xpath = "//*[@id='closeOverlay']")
    private WebElement closeCookiesMessageButton;
    @FindBy(xpath = "//*[@id='international-overlay']/div/div/div/button")
    private WebElement closeAdButton;
    @FindBy(xpath = "//*[@id='size-error']")
    private WebElement cartMessageTip;

    public GucciItemPage(WebDriver driver) {
        super(driver);
    }

    public GucciItemPage openPage() {
        driver.get(PAGE_URL);
        new WebDriverWait(driver, WAIT_TIMEOUT_SECONDS)
                .until(PageLoaded());
        return this;
    }


    public GucciItemPage closePopUps() {
        new WebDriverWait(driver, WAIT_TIMEOUT_SECONDS)
                .until(ExpectedConditions.visibilityOf(closeCookiesMessageButton));
        closeCookiesMessageButton.click();
        return this;
    }

    public Boolean areWidthAndSizeSelected() {
        Actions moveToButton = new Actions(driver);
        moveToButton.moveToElement(addToCartButton);
        moveToButton.perform();
        addToCartButton.click();
        new WebDriverWait(driver, WAIT_TIMEOUT_SECONDS)
                .until(ExpectedConditions.presenceOfElementLocated(By.xpath("//*[@id='size-error']")));
        return !(cartMessageTip.isDisplayed());
    }

}
