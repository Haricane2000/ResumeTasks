package page;
import model.Item;
import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.chrome.ChromeDriver;
import org.openqa.selenium.support.FindBy;
import org.openqa.selenium.support.PageFactory;
import org.openqa.selenium.support.ui.ExpectedCondition;
import org.openqa.selenium.support.ui.ExpectedConditions;
import org.openqa.selenium.support.ui.WebDriverWait;
import org.openqa.selenium.WebElement;

public class GucciWishlistPage {

    private WebDriver driver;
    private final By closeDialogLocator = By.xpath("//button[@class=\"gl-modal__close\"]");
    private final By amountLocator = By.xpath("//div[@data-auto-id=\"my-wishlist-view-container\"]/p");
    private final By itemNameLocator = By.xpath("//div[@class=\"gl-product-card__details-main\"]/span");
    private final By itemPriceLocator = By.xpath("//div[@class=\"gl-product-card__details-main\"]/div");

    public GucciWishlistPage(WebDriver driver){
        this.driver = driver;
    }

    public Item getWishlistResult(){
        WebElement closeDialogBnt = new WebDriverWait(driver, 10)
                .until(ExpectedConditions.presenceOfElementLocated(closeDialogLocator));
        closeDialogBnt.click();
        String itemName = new WebDriverWait(driver, 10)
                .until(ExpectedConditions.presenceOfElementLocated(itemNameLocator)).getText();
        String itemPrice = new WebDriverWait(driver, 10)
                .until(ExpectedConditions.presenceOfElementLocated(itemPriceLocator)).getText();
        String amount = new WebDriverWait(driver, 10)
                .until(ExpectedConditions.presenceOfElementLocated(amountLocator)).getText();
        return new Item(itemName,null,null,itemPrice, amount);
    }
}
