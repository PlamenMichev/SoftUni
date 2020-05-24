function calculatePrice(type, weight, priceInKg) {
    let weightInKg = weight / 1000;
    let totalPrice = weightInKg * priceInKg;

    console.log(`I need $${totalPrice.toFixed(2)} to buy ${weightInKg.toFixed(2)} kilograms ${type}.`);
}

calculatePrice('apple', 1563, 2.35);