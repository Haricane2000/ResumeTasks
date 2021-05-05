package util;

import org.openqa.selenium.WebElement;

import java.util.ArrayList;
import java.util.List;

public class Resolver {

    public static String resolveTemplate(String template, String data){
        return String.format(template, data);
    }

    public static List  getPriceList(List<WebElement> webElementList, String listType){
        List priceList = new ArrayList<>();
        switch(listType){
            case "Integer": {
                priceList.add(Integer.parseInt(webElementList.get(0).getText().substring(1)));
                priceList.add(Integer.parseInt(webElementList.get(1).getText().substring(1)));
            }
            case "Double": {
                priceList.add(Double.parseDouble(webElementList.get(0).getText().substring(2)));
                priceList.add(Double.parseDouble(webElementList.get(1).getText().substring(2)));
            }
        }
        return priceList;
    }

}
