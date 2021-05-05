import org.openqa.selenium.WebDriver;
import org.openqa.selenium.chrome.ChromeDriver;
import org.testng.Assert;
import org.testng.annotations.*;
import pageobject.gucci.GucciAccountPage;
import pageobject.gucci.GucciItemPage;

public class GucciTest {

    private WebDriver driver;

    @BeforeTest
    public void init() {
        driver = new ChromeDriver();
    }

    @Test
    public void addToCartWithoutSelectingSizeOrWidth() {
        Boolean widthAndSizeSelected = new GucciItemPage(driver)
                .openPage()
                .closePopUps()
                .areWidthAndSizeSelected();
        Assert.assertFalse(widthAndSizeSelected, "Width and Size were selected!");
    }

    @Test
    public void loginWithBadEmailAndPassword() {
        Boolean canLogin = new GucciAccountPage(driver)
                .openPage()
                .setEmail("qweasd.com")
                .canLogin();
        Assert.assertFalse(canLogin, "Login and Password were correct!");
    }

    @AfterTest
    public void closeDriver() {
        driver.quit();
    }
}
