let expect = require('chai').expect;
let sum = require('./sumFunc');

it('Sum should throw exception when not array', () => {
    let result = 'arr is not iterable';

    try {
        let result = sum(123);
    } catch (error) {
        expect(result).to.equal(error.message);
    }
});

it('Sum should calculate properly', () => {
    let result = sum([12, 3, 5]);
    let expected = 20;

    expect(result).to.equal(expected);
});

it('Sum should return NaN', () => {
    let result = sum([12, 'a', 5]);

    expect(result).to.be.NaN;
});