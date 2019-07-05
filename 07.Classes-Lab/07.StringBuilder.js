class StringBuilder {
    constructor(string) {
      if (string !== undefined) {
        StringBuilder._vrfyParam(string);
        this._stringArray = Array.from(string);
      } else {
        this._stringArray = [];
      }
    }
  
    append(string) {
      StringBuilder._vrfyParam(string);
      for(let i = 0; i < string.length; i++) {
        this._stringArray.push(string[i]);
      }
    }
  
    prepend(string) {
      StringBuilder._vrfyParam(string);
      for(let i = string.length - 1; i >= 0; i--) {
        this._stringArray.unshift(string[i]);
      }
    }
  
    insertAt(string, startIndex) {
      StringBuilder._vrfyParam(string);
      this._stringArray.splice(startIndex, 0, ...string);
    }
  
    remove(startIndex, length) {
      this._stringArray.splice(startIndex, length);
    }
  
    static _vrfyParam(param) {
      if (typeof param !== 'string') throw new TypeError('Argument must be string');
    }
  
    toString() {
      return this._stringArray.join('');
    }
  }
  
let { expect } = require('chai');

describe('All tests', () => {
    it('Class should be initialized', () => {
        let instance = new StringBuilder();
        let secondInstance = new StringBuilder('Plamen');

        expect(instance.toString()).to.equal('');
        expect(secondInstance.toString()).to.equal('Plamen');

    });

    it('Append should work correctly', () => {
        let instance = new StringBuilder('Plamen');
        instance.append('Plamen');

        expect(instance.toString()).to.equal('PlamenPlamen');
    });

    it('Prepend should work correctly', () => {
        let instance = new StringBuilder('Plamen');
        instance.prepend('as');

        expect(instance.toString()).to.equal('asPlamen');
    });

    it('InsertAt should work correctly', () => {
        let instance = new StringBuilder('Plamen');
        instance.insertAt('aha', 0);

        expect(instance.toString()).to.equal('ahaPlamen');
    });

    it('Remove should work correctly', () => {
        let instance = new StringBuilder('Plamen');
        instance.remove(0, 3);

        expect(instance.toString()).to.equal('men');
    });

    it('ToString should work correctly', () => {
        let instance = new StringBuilder('Plamen');
        instance.append('003');

        expect(instance.toString()).to.equal('Plamen003');
    });

    it('Class should throw error', () => {
        try {
            let instance = new StringBuilder(123);
        } catch (error) {
            expect('Argument must be string').to.equal(error.message);
        }
    });

    it('Class should throw error', () => {
        try {
            let instance = new StringBuilder('apasd', false);
        } catch (error) {
            expect('Argument must be string').to.equal(error.message);
        }
    });
});
