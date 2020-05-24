let { expect } = require('chai');
let rgbToHexColor = require('./func');

it('Func works correctly', () => {
    let expected = '#0C7B36';
    let result = rgbToHexColor(12, 123, 54);

    expect(result).to.equal(expected);
});

it('Func returns undefined when invalid color is passed', () => {
    let expected = undefined;
    let result = rgbToHexColor('asd', 123, 54);

    expect(result).to.equal(expected);
});

it('Func returns undefined when invalid color is passed', () => {
    let expected = undefined;
    let result = rgbToHexColor(-12, 123, 54);

    expect(result).to.equal(expected);
});

it('Func returns undefined when invalid color is passed', () => {
    let expected = undefined;
    let result = rgbToHexColor(12412, 123, 54);

    expect(result).to.equal(expected);
});

it('Func returns undefined when invalid color is passed', () => {
    let expected = undefined;
    let result = rgbToHexColor(12, 'plamen', 54);

    expect(result).to.equal(expected);
});

it('Func returns undefined when invalid color is passed', () => {
    let expected = undefined;
    let result = rgbToHexColor(12, -12, 54);

    expect(result).to.equal(expected);
});

it('Func returns undefined when invalid color is passed', () => {
    let expected = undefined;
    let result = rgbToHexColor(12, 12421, 54);

    expect(result).to.equal(expected);
});

it('Func returns undefined when invalid color is passed', () => {
    let expected = undefined;
    let result = rgbToHexColor(12, 2, 'koko');

    expect(result).to.equal(expected);
});

it('Func returns undefined when invalid color is passed', () => {
    let expected = undefined;
    let result = rgbToHexColor(12, 23, -12);

    expect(result).to.equal(expected);
});

it('Func returns undefined when invalid color is passed', () => {
    let expected = undefined;
    let result = rgbToHexColor(12, 2, 1421);

    expect(result).to.equal(expected);
});

it('Func returns undefined when 255 is passed', () => {
    let expected = undefined;
    let result = rgbToHexColor(12, 2, 256);

    expect(result).to.equal(expected);
});

it('Func returns undefined when 255 is passed', () => {
    let expected = undefined;
    let result = rgbToHexColor(256, 2, 12);

    expect(result).to.equal(expected);
});

it('Func returns undefined when 255 is passed', () => {
    let expected = undefined;
    let result = rgbToHexColor(3, 256, 12);

    expect(result).to.equal(expected);
});

it('Func returns undefined when -1 is passed', () => {
    let expected = undefined;
    let result = rgbToHexColor(3, -1, 12);

    expect(result).to.equal(expected);
});

it('Func returns undefined when -1 is passed', () => {
    let expected = undefined;
    let result = rgbToHexColor(-1, 11, 12);

    expect(result).to.equal(expected);
});

it('Func returns undefined when -1 is passed', () => {
    let expected = undefined;
    let result = rgbToHexColor(3, 14, -1);

    expect(result).to.equal(expected);
});

it('Func returns undefined when invalid color is passed', () => {
    let expected = undefined;
    let result = rgbToHexColor(12.2, 12421, 54);

    expect(result).to.equal(expected);
});

it('Func returns undefined when invalid color is passed', () => {
    let expected = undefined;
    let result = rgbToHexColor(12, 12421.12, 54);

    expect(result).to.equal(expected);
});

it('Func returns undefined when invalid color is passed', () => {
    let expected = undefined;
    let result = rgbToHexColor(12, 12421, 54.3);

    expect(result).to.equal(expected);
});

it('Func works correctly', () => {
    let expected = '#007B36';
    let result = rgbToHexColor(0, 123, 54);

    expect(result).to.equal(expected);
});

it('Func works correctly', () => {
    let expected = '#0C0036';
    let result = rgbToHexColor(12, 0, 54);

    expect(result).to.equal(expected);
});

it('Func works correctly', () => {
    let expected = '#0C0A00';
    let result = rgbToHexColor(12, 10, 0);

    expect(result).to.equal(expected);
});

it('Func works correctly', () => {
    let expected = '#FF0A00';
    let result = rgbToHexColor(255, 10, 0);

    expect(result).to.equal(expected);
});