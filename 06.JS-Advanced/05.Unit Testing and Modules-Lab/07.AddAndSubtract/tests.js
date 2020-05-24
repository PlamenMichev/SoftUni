let { expect } = require('chai');
let createCalculator = require('./func');

it('Func should return objects containing all values', () => {
    let result = Object.keys(createCalculator());
    let expected = 'add';

    expect(result[0]).to.eql(expected);
    expect(result[1]).to.eql('subtract');
    expect(result[2]).to.eql('get');
});

it('Is value changable from outside', () => {
    let result = createCalculator();
    let expected = undefined;

    expect(result.value).to.eql(expected);
});

it('Sum func should work', () => {
    let result = createCalculator();
    let expected = 12;
    result.add(12);

    expect(result.get()).to.eql(expected);
});

it('Sum func should work', () => {
    let result = createCalculator();
    let expected = 12;
    result.add('12');
    
    expect(result.get()).to.eql(expected);
});



