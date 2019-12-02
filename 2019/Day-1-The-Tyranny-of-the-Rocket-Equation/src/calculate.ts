
const calculateFuel = (mass: number):number => {
    const fuel =  Math.max(Math.floor((mass / 3)) - 2, 0);
    const fuelForFuel = fuel > 0 ? calculateFuel(fuel) : 0
    return fuel + fuelForFuel
};

export default calculateFuel