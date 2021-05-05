package model;

import java.util.Objects;

public class Item {

    private String name;
    private String color;
    private String size;
    private String price;
    private String amount;


    public Item(String name, String color, String size, String price, String amount) {
        this.name = name;
        this.color = color;
        this.size = size;
        this.price = price;
        this.amount = amount;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getColor() {
        return color;
    }

    public void setColor(String color) {
        this.color = color;
    }

    public String getSize() {
        return size;
    }

    public void setSize(String size) {
        this.size = size;
    }

    public String getAmount() {
        return amount;
    }

    public void setAmount(String amount) {
        this.amount = amount;
    }

    public String getPrice() {
        return price;
    }

    public void setPrice(String price) {
        this.price = price;
    }


    @Override
    public String toString() {
        return "Item{" +
                "name='" + name + '\'' +
                ", color='" + color + '\'' +
                ", size='" + size + '\'' +
                ", price='" + price + '\'' +
                ", amount='" + amount + '\'' +
                '}';
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (!(o instanceof Item)) return false;
        Item item = (Item) o;
        return Objects.equals(getName(), item.getName()) &&
                Objects.equals(getColor(), item.getColor()) &&
                Objects.equals(getSize(), item.getSize()) &&
                Objects.equals(getPrice(), item.getPrice()) &&
                Objects.equals(getAmount(), item.getAmount());
    }

    @Override
    public int hashCode() {
        return Objects.hash(getName(), getColor(), getSize(), getPrice(), getAmount());
    }
}
