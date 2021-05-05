package page;

import model.User;
import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.support.ui.ExpectedConditions;
import org.openqa.selenium.support.ui.WebDriverWait;

import java.util.List;

public class GucciCheckoutPage {

    private final By firstnameInputFieldLocator = By.xpath("//input[@id= \"shippingAddress-firstName\"]");
    private final By lastnameInputFieldLocator = By.xpath("//input[@id= \"shippingAddress-lastName\"]");
    private final By addressInputFieldLocator = By.xpath("//input[@data-auto-id= \"inline-search-input\"]");
    private final By emailInputFieldLocator = By.xpath("//input[@id= \"shippingAddress-emailAddress\"]");
    private final By phoneNumberInputFieldLocator = By.xpath("//input[@id= \"shippingAddress-phoneNumber\"]");
    private final By reviewAndPayLocator = By.xpath("//button[@data-auto-id = \"review-and-pay-button\"]");
    private final By errorMessageLocator = By.xpath("//div[@class = \"gl-form-hint gl-form-hint--error\"]");

    private WebDriver driver;

    public GucciCheckoutPage(WebDriver driver){
        this.driver = driver;
    }

    public GucciCheckoutPage enterCredentials(User user){
        WebElement addressField = new WebDriverWait(driver,10)
                .until(ExpectedConditions.presenceOfElementLocated(addressInputFieldLocator));
        addressField.sendKeys(user.getAddress());
        WebElement emailField = new WebDriverWait(driver,10)
                .until(ExpectedConditions.presenceOfElementLocated(emailInputFieldLocator));
        emailField.sendKeys(user.getEmail());
        WebElement phoneField = new WebDriverWait(driver,10)
                .until(ExpectedConditions.presenceOfElementLocated(phoneNumberInputFieldLocator));
        phoneField.sendKeys(user.getPhoneNumber());
        WebElement firstnameField = new WebDriverWait(driver,10)
                .until(ExpectedConditions.presenceOfElementLocated(firstnameInputFieldLocator));
        firstnameField.sendKeys(user.getFirstName());
        WebElement lastnameField = new WebDriverWait(driver,10)
                .until(ExpectedConditions.presenceOfElementLocated(lastnameInputFieldLocator));
        lastnameField.sendKeys(user.getAddress());
        WebElement reviewAndPayBtn = new WebDriverWait(driver,10)
                .until(ExpectedConditions.presenceOfElementLocated(reviewAndPayLocator));
        reviewAndPayBtn.click();
        return this;
    }

    public List<WebElement> getAddressMessage(){
        return new WebDriverWait(driver,10)
                .until(ExpectedConditions.presenceOfAllElementsLocatedBy(errorMessageLocator));
    }

}
