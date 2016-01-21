import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;

/**
 * 
 * @author Madhu Meghana Talasila
 *
 */
public class AssignCarToDriver {

	/**
	 * 
	 * @param args
	 */
	public static void main(String args[]){

		List<Car> carList = createCarList();
		List<Driver> driverList = createDriverList();
		
		//HashMap to store carNumber and its respective driverNumber
		HashMap<String, String> assignedMap = new HashMap<String, String>();
		
		for(int i=0,j=0; i<carList.size() && j<driverList.size(); i++,j++){
			assignedMap.put(carList.get(i).getCarNumber(), driverList.get(j).getDriverId());
		}
	}
	
	/**
	 * 
	 * @return List of Car Objects
	 */
	private static List<Car> createCarList(){
		List<Car> carList = new ArrayList<Car>();
		carList.add(new Car("1"));
		carList.add(new Car("2"));
		carList.add(new Car("3"));
		
		return carList;
	}
	
	/**
	 * 
	 * @return List of Driver Objects
	 */
	private static List<Driver> createDriverList(){
		List<Driver> driverList = new ArrayList<Driver>();
		driverList.add(new Driver("1"));
		driverList.add(new Driver("2"));
		driverList.add(new Driver("3"));
		
		return driverList;
	}
	
}
