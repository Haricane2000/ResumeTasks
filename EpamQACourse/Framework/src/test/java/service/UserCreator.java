package service;

import model.User;


public class UserCreator {

    public static final String FIRST_NAME = "testdata.user.firstname";
    public static final String LAST_NAME = "testdata.user.lastname";
    public static final String ADDRESS = "testdata.user.address";
    public static final String EMAIL = "testdata.user.email";
    public static final String PHONE_NUMBER = "testdata.user.phonenumber";

    public static User withIncorrectAddress(){
        return new User(TestDataReader.getTestData(FIRST_NAME),
                TestDataReader.getTestData(LAST_NAME),
                TestDataReader.getTestData(ADDRESS),
                TestDataReader.getTestData(EMAIL),
                TestDataReader.getTestData(PHONE_NUMBER));
    }

    public static User withEmptyFirstname(){
        return new User("",
                TestDataReader.getTestData(LAST_NAME),
                TestDataReader.getTestData(ADDRESS),
                TestDataReader.getTestData(EMAIL),
                TestDataReader.getTestData(PHONE_NUMBER));
    }

    public static User withEmptyLastname(){
        return new User(TestDataReader.getTestData(FIRST_NAME),
                "",
                TestDataReader.getTestData(ADDRESS),
                TestDataReader.getTestData(EMAIL),
                TestDataReader.getTestData(PHONE_NUMBER));
    }

    public static User withIncorrectEmail(){
        return new User(TestDataReader.getTestData(FIRST_NAME),
                TestDataReader.getTestData(LAST_NAME),
                TestDataReader.getTestData(ADDRESS),
                "Actually not email",
                TestDataReader.getTestData(PHONE_NUMBER));
    }

    public static User withIncorrectPhoneNumber(){
        return new User(TestDataReader.getTestData(FIRST_NAME),
                TestDataReader.getTestData(LAST_NAME),
                TestDataReader.getTestData(ADDRESS),
                TestDataReader.getTestData(EMAIL),
                "This is not phone number");
    }
}
