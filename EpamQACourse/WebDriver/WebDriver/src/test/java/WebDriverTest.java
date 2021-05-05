import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.chrome.ChromeDriver;
import org.openqa.selenium.interactions.Actions;
import org.openqa.selenium.support.ui.ExpectedConditions;
import org.openqa.selenium.support.ui.WebDriverWait;
import org.testng.Assert;
import org.testng.annotations.*;

public class WebDriverTest {

    @Test
    public void addToBagWithoutSelectedSize() throws InterruptedException {
        WebDriver driver = new ChromeDriver();

        driver.get("https://www.gucci.com/pl/en_gb/pr/men/ready-to-wear-for-men/coats-for-men/coats-for-men/ken-scott-print-velvet-coat-p-643978Z8AL61067");

        WebElement addToBagButton = new WebDriverWait(driver, 10)
                .until(ExpectedConditions.presenceOfElementLocated(By.xpath("//*[@id='product-detail-add-to-shopping-bag-form']/div/button")));
        Actions moveToButton = new Actions(driver);
        moveToButton.moveToElement(addToBagButton);
        moveToButton.perform();
        WebElement closeAdvertising = new WebDriverWait(driver, 10)
                .until(ExpectedConditions.presenceOfElementLocated(By.xpath("//*[@id='international-overlay']/div/div/div/button")));
        closeAdvertising.click();
        addToBagButton.click();
        WebElement errorMessage = new WebDriverWait(driver, 10)
                .until(ExpectedConditions.presenceOfElementLocated(By.xpath("//*[@id='size-error']")));

        Assert.assertTrue(errorMessage.isDisplayed(), "Message did not show!");

        driver.quit();
    }


}
