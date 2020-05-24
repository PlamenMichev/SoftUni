function solve(commands) {
    let pilots = [];
    let pilotsArgs = commands[0].split(/\s+/gm);

    for (let i = 0; i < pilotsArgs.length; i++) {
        pilots.push(pilotsArgs[i]);
    }

    for (let command of commands.splice(1)) {
        let [currentCommand, pilot] = command.split(/\s+/gm);
        if (currentCommand === 'Join') {
            if (pilots.includes(pilot) === false) {
                pilots.push(pilot);
            }
        } else if (currentCommand === 'Crash') {
            if (pilots.includes(pilot) === true) {
                let index = pilots.indexOf(pilot);
                pilots.splice(index, 1);
            }
        } else if (currentCommand === 'Pit') {
            if (pilots.includes(pilot) === true) {
                let index = pilots.indexOf(pilot);
                if (index !== pilots.length - 1) {
                    let helpVar = '';
                    let currentPilot = pilots[index];
                    helpVar = pilots[index + 1];
                    pilots[index + 1] = currentPilot;
                    pilots[index] = helpVar;
                }
            } 
        } else if (currentCommand === 'Overtake') {
            if (pilots.includes(pilot) === true) {
                let index = pilots.indexOf(pilot);
                if (index !== 0) {
                    let helpVar = '';
                    let currentPilot = pilots[index];
                    helpVar = pilots[index - 1];
                    pilots[index - 1] = currentPilot;
                    pilots[index] = helpVar;
                }
            }
    }
}

console.log(pilots.join(' ~ '))
}

solve(["Vetel Hamilton Raikonnen Botas Slavi",
"Pit Hamilton",
"Overtake LeClerc",
"Join Ricardo",
"Crash Botas",
"Overtake Ricardo",
"Overtake Ricardo",
"Overtake Ricardo",
"Crash Slavi"]

)