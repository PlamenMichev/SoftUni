function attachEventsListeners() {
    let allToKilometres = {
        km: 1,
        m: 1000,
        cm: 100000,
        mm: 1000000,
        mi: 0.621371192,
        yrd: 1093.6133,
        ft: 3280.8399,
        in: 39370.0787
    };


    let convertButton = document.getElementById('convert');
    convertButton.addEventListener('click', () => {
        let distanceToConvert = Number(document.getElementById('inputDistance').value);     
        let distanceToConvertType = document.getElementById('inputUnits').value;
        let outputType = document.getElementById('outputUnits').value;
        let resultBox = document.getElementById('outputDistance');
        let typeToConvertToKm = distanceToConvert / allToKilometres[distanceToConvertType];
        let result = typeToConvertToKm * allToKilometres[outputType]; 
        resultBox.value = result;
    });
}