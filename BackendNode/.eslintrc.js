module.exports = {
  'env': {
    'browser': true,
    'commonjs': true,
    'es2020': true,
  },
  'extends': [
    'google',
  ],
  'parser': 'babel-eslint',
  'parserOptions': {
    'ecmaVersion': 11,
    'ecmaVersion': 6,
    'sourceType': 'module',
    'ecmaFeatures': {
      'jsx': true,
      'modules': true,
      'experimentalObjectRestSpread': true
    }
  },
  'rules': {
    'require-jsdoc': 0,
  },
};
