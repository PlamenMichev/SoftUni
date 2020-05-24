function solve() {
    let addTruckButton = document.getElementsByTagName('button')[0];
    let addTiresButton = document.getElementsByTagName('button')[1];
    let goToWorkButton = document.getElementsByTagName('button')[2];
    let endButton = document.getElementsByTagName('button')[3];
    let trucksElementFieldset = document.getElementsByTagName('fieldset')[4];
    let trcukElement = trucksElementFieldset.children[1];
    let tiresElementFieldset = document.getElementsByTagName('fieldset')[3];
    let tiresElement = tiresElementFieldset.children[1];
    let trucks = {};
    let backupTires = [];

    addTruckButton.addEventListener('click', () => {
        let plateNumber = document.getElementById('newTruckPlateNumber').value;
        let tiresCondition = document.getElementById('newTruckTiresCondition').value.split(' ').map(Number);
        console.log(tiresCondition)
        if (!trucks[plateNumber]) {
            trucks[plateNumber] = {};
            trucks[plateNumber].tires = tiresCondition;
            trucks[plateNumber].distance = 0;
            let newTruck = document.createElement('div');
            newTruck.className = 'truck';
            newTruck.textContent = plateNumber;
            trcukElement.appendChild(newTruck);
        }

        console.log(trucks);
    });

    addTiresButton.addEventListener('click', () => {
        let tiresCondition = document.getElementById('newTiresCondition').value.split(' ').map(Number);
        backupTires.push(tiresCondition);
            let newTires = document.createElement('div');
            newTires.textContent = tiresCondition.join(' ');
            newTires.className = 'tireSet';
            tiresElement.appendChild(newTires);
        

        console.log(backupTires);
    });

    goToWorkButton.addEventListener('click', () => {
        let plateNumber = document.getElementById('workPlateNumber').value;
        let distance = +document.getElementById('distance').value;
        if (trucks.hasOwnProperty(plateNumber)) {
            let tiresConditionNeeded = distance / 1000;
            let canTravel = true;
            let crashedTires = [];
            for (let element of trucks[plateNumber].tires) {
                if (+element < tiresConditionNeeded) {
                    if (backupTires.length > 0) {
                        let newSetOfTires = backupTires.shift();
                        tiresElement.removeChild(tiresElement.children[0]);
                        trucks[plateNumber].tires = newSetOfTires;
                        canTravel = false;
                        break;
                    }
                } else {
                    element -= tiresConditionNeeded;
                    crashedTires.push(element);
                }
            };

            if (canTravel === false) {
                crashedTires = [];
                canTravel = true;
                for (let element of trucks[plateNumber].tires) {
                    console.log(+element < tiresConditionNeeded)
                    if (+element < tiresConditionNeeded) {
                            canTravel = false;
                            break;
                        }
                     else {
                        element -= tiresConditionNeeded;
                        crashedTires.push(element);
                    }
                };

                if (canTravel === true) {
                    trucks[plateNumber].distance += distance;
                    trucks[plateNumber].tires = crashedTires;
                }
            } else {
                trucks[plateNumber].distance += distance;
                trucks[plateNumber].tires = crashedTires;
            }

            

            console.log(trucks[plateNumber].distance, trucks[plateNumber].tires)
        }
    });

    endButton.addEventListener('click', () => {
        let outputElement = document.getElementsByTagName('textarea')[0];
        for (let truck in trucks) {
            outputElement.textContent += `Truck ${truck} has traveled ${trucks[truck].distance}.\n`
        }

        outputElement.textContent += `You have ${backupTires.length} sets of tires left.\n`;
    });
}