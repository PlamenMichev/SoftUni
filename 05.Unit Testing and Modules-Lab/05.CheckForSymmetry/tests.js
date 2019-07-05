let { expect } = require('chai');
let isSymmetric = require('./func');
describe('All tests', () => {
    it('Func should return false when non-array is passed', () => {
        let expected = false;
        let result = isSymmetric(12);

        expect(expected).to.equal(result);
    });

    it('Func should return true if symmetric', () => {
        let expected = true;
        let result = isSymmetric([12, 2, 12]);

        expect(result).to.equal(expected);
    });

    it('Func should return false if not symmetric', () => {
        let expected = false;
        let result = isSymmetric([12, 2, 1]);

        expect(result).to.equal(expected);
    });

    it('Func should not change the array', () => {
        let arr = ['b', 'o', 'a'];
        let result = isSymmetric(['b', 'o', 'a']);

        expect(arr).to.eql(['b', 'o', 'a']);
    });

    it('Func should return true if arr is empty', () => {
        let expected = true;
        let result = isSymmetric([]);

        expect(expected).to.eql(result);
    });

    it('Func should return false when none is passed', () => {
        let expected = false;
        let result = isSymmetric();

        expect(expected).to.equal(result);
    });

    it('Func should return true with odd array', () => {
        let expected = true;
        let result = isSymmetric([12, 15, 12, 15, 12]);

        expect(expected).to.equal(result);
    });

    it('Func should return false when string is passed', () => {
        let expected = false;
        let result = isSymmetric('plamen e silen');

        expect(result).to.equal(expected);
    });

    it('Func should return true', () => {
        let expected = true;
        let result = isSymmetric([{ a: 1 }, ['a', '1'], ['a', '1'], { a: 1 }]);
        expect(result).to.be.equal(expected);
    });
})