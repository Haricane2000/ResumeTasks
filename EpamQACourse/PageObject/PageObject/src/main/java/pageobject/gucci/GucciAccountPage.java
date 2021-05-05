package pageobject.gucci;

import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.support.FindBy;
import org.openqa.selenium.support.ui.ExpectedConditions;
import org.openqa.selenium.support.ui.WebDriverWait;
import pageobject.Page;

public class GucciAccountPage extends Page {

    private final String PAGE_URL = "https://www.gucci.com/us/en/access/view?stateToken=24D3B05ED7CAACEAE94D6030ADA8A505&nonce=5A8CD748907233ECAB51DED7190B5943&returnURI=%2F";

    @FindBy(xpath = "//*[@id='form']/button")
    private WebElement loginButton;
    @FindBy(xpath = "//*[@id='email-input']")
    private WebElement emailBox;
    @FindBy(id = "//*[@id='form']/button")
    private WebElement passwordBox;
    @FindBy(xpath = "//*[@id='email-input-error']")
    private WebElement FailedLoginAttemptErrorMessage;


    @FindBy(xpath = "//*[@id='closeOverlay']")
    private WebElement closeCookiesMessageButton;


    public GucciAccountPage(WebDriver driver) {
        super(driver);
    }

    public GucciAccountPage openPage() {
        driver.get(PAGE_URL);
        new WebDriverWait(driver, WAIT_TIMEOUT_SECONDS)
                .until(PageLoaded());
        return this;
    }

    public GucciAccountPage closePopUps() {
        new WebDriverWait(driver, WAIT_TIMEOUT_SECONDS)
                .until(ExpectedConditions.visibilityOf(closeCookiesMessageButton));
        closeCookiesMessageButton.click();
        return this;
    }

    public GucciAccountPage setEmail(String email)
    {
        emailBox.sendKeys(email);
        return this;
    }



    public Boolean canLogin() {
        loginButton.click();

        new WebDriverWait(driver, WAIT_TIMEOUT_SECONDS)
                .until(PageLoaded());

        return !(FailedLoginAttemptErrorMessage.isDisplayed());
    }
}
