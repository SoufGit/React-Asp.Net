import React from 'react';
import Button from '@material-ui/core/Button';
import { ValidatorForm, TextValidator } from 'react-material-ui-form-validator';
import CircularProgress from '@material-ui/core/CircularProgress';

const LoginView = ({
  email,
  setEmail,
  password,
  setPassword,
  handleSubmit,
  isLoading,
  btnColor,
  setBtnColor,
}) => {
  return (
    <ValidatorForm
      className="loginForm"
      onSubmit={handleSubmit}
      onError={errors => {
        console.log('errors', errors);
        setBtnColor('secondary');
      }}
    >
      <div>
        <TextValidator
          label="Email"
          onChange={e => {
            setEmail(e.target.value);
            setBtnColor(email && password ? 'primary' : 'secondary');
          }}
          name="email"
          value={email}
          validators={['required', 'isEmail']}
          errorMessages={['Email obligatoire', 'Email invalide']}
        />
      </div>
      <div>
        <TextValidator
          label="Password"
          onChange={e => {
            setPassword(e.target.value);
            setBtnColor(email && password ? 'primary' : 'secondary');
          }}
          name="password"
          type="password"
          validators={['required']}
          errorMessages={['Password obligatoire']}
          value={password}
        />
      </div>
      <div className="wrapper">
        <Button
          variant="contained"
          color={btnColor}
          type="submit"
          disabled={isLoading}
        >
          Valider
          {isLoading && <CircularProgress size={24} className="" />}
        </Button>
      </div>
    </ValidatorForm>
  );
};

export default LoginView;
