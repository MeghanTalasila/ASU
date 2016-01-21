/**
 * 
 * @author Madhu Meghana Talasila
 *
 */
public class Car {	
	
	//Car Number
	private String carNumber;
	
	//Setters and Getters
	public String getCarNumber() {
		return carNumber;
	}
	public void setCarNumber(String carNumber) {
		this.carNumber = carNumber;
	}
	
	//Constructor
	public Car(String carNumber) {
		super();
		this.carNumber = carNumber;
	}	
}
