import { isLowerCase } from './lower-case.validator';

describe('The function isLowerCase', () => {
    it('must confirm when receiving a lower case text', () => {
        const value = 'mario';
        const result = isLowerCase(value);
        expect(result).toBeTruthy();
    });

    it('must reject when receiving an upper case text', () => {
        const value = 'MARIO';
        const result = isLowerCase(value);
        expect(result).toBeFalsy();
    });

    it('must reject when receiving at least an upper case letter', () => {
        const value = 'Mario';
        const result = isLowerCase(value);
        expect(result).toBeFalsy();
    });
});
