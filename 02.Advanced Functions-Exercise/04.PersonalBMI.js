function result(name, age, weight, height) {
    let bmi = (weight / ((height / 100) * (height / 100)));
    let status = '';
    let personalInformation = {age: age, weight: weight, height: height};
    let client = {name: name, personalInfo: personalInformation};

    if (bmi < 18.5) {
        status = 'underweight';
    }
    else if (bmi < 25) {
        status = 'normal';
    }
    else if (bmi < 30) {
        status = 'overweight';
    }
    else if (bmi >= 30) {
        status = 'obese';
        client.recommendation = 'admission required';
    }

    client.BMI = Math.round(bmi);
    client.status = status;

    return client;
}

let test = result('“Peter”', 29, 75, 182);
console.log(typeof test);