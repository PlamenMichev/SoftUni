function solve(worker) {
    if (worker.dizziness === true) {
        let neededWater = (worker.weight * worker.experience) * 0.1;
        worker.levelOfHydrated += neededWater;
        worker.dizziness = false;
    }

    return worker;
}

console.log(solve({ weight: 95,
    experience: 3,
    levelOfHydrated: 0,
    dizziness: false }
  
  
  ))