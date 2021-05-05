package page;

import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.support.ui.ExpectedConditions;
import org.openqa.selenium.support.ui.WebDriverWait;
import util.Resolver;

import java.util.List;
import java.util.regex.Pattern;

public class GucciCatalogPage extends AbstractPage  {

    private final By closeModalLocator = By.xpath("//button[@class=\"gl-modal__close\"]");
    private final By colorFilterLocator = By.xpath("//span[@title=\"Color\"]");
    private final By colorLocator = By.xpath("//a[@title = \"Purple\"]");
    private final By itemByFilterLocator = By.xpath("//div[@data-grid-id = \"FZ0832\"]");
    private final By sortByDropdownLocator = By.xpath("//button[@title= \"Sort By\"]");
    private final By priceHighToLowLocator = By.xpath("//button[@value= \"price-high-to-low\"]");
    private final By priceHighToLowSelectedLocator = By.xpath("//span[@class=\"gl-dropdown-custom__select-label-text\" and text() = \"Price (high - low)\"]");
    private final By itemsPriceLocator = By.xpath("//div[@class= \"gl-price-item gl-price-item--small notranslate\"]");
    private String url;
    public GucciCatalogPage(WebDriver driver, String hoodieUrl){
        super(driver);
        this.url = hoodieUrl;
    }

    @Override
    public GucciCatalogPage openPage() {
        driver.get(url);
        return this;
    }

    public GucciCatalogPage applyColorFilter(){
        WebElement colorFilterBtn = new WebDriverWait(driver,20)
                .until(ExpectedConditions.presenceOfElementLocated(colorFilterLocator));
        colorFilterBtn.click();
        WebElement colorBtn = new WebDriverWait(driver,10)
                .until(ExpectedConditions.presenceOfElementLocated(colorLocator));
        colorBtn.click();
        WebElement closeModalBtn = new WebDriverWait(driver,10)
                .until(ExpectedConditions.presenceOfElementLocated(closeModalLocator));
        closeModalBtn.click();
        return this;
    }

    public GucciProductPage openItemWithFilter(){
        WebElement itemByFilterBtn = new WebDriverWait(driver,10)
                .until(ExpectedConditions.presenceOfElementLocated(itemByFilterLocator));
        itemByFilterBtn.click();
        return new GucciProductPage(driver);
    }

    public GucciCatalogPage sortByPrice() {
        WebElement sortByDropdown = new WebDriverWait(driver,10)
                .until(ExpectedConditions.presenceOfElementLocated(sortByDropdownLocator));
        sortByDropdown.click();
        WebElement priceHighToLowBtn = new WebDriverWait(driver,10)
                .until(ExpectedConditions.presenceOfElementLocated(priceHighToLowLocator));
        priceHighToLowBtn.click();
        WebElement closeModalBtn = new WebDriverWait(driver,10)
                .until(ExpectedConditions.presenceOfElementLocated(closeModalLocator));
        closeModalBtn.click();
        new WebDriverWait(driver,10)
                .until(ExpectedConditions.presenceOfElementLocated(priceHighToLowSelectedLocator));
        new WebDriverWait(driver,10)
                .until(ExpectedConditions.textMatches(itemsPriceLocator, Pattern.compile(".+")));
        return this;
    }

    public List<Integer> getItemsPriceList(){
        List<Integer> priceList = Resolver.getPriceList(new WebDriverWait(driver,20)
              .until(ExpectedConditions.numberOfElementsToBeMoreThan(itemsPriceLocator,1)), "Integer");
        return priceList;
    }
}
