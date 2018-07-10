import React from 'react';
import PropTypes from 'prop-types';
import { Alert, Glyphicon, ControlLabel } from 'react-bootstrap';
import axios from 'axios';
import { compose, withHandlers, withState } from 'recompose';
import LoginView from './loginView';

const LoginContainer = ({
  email,
  setEmail,
  password,
  setPassword,
  handleSubmit,
  isLoading,
  btnColor,
  setBtnColor,
  success,
  authenticateRes,
  confidentialsRes,
}) => {
  return (
    <div>
      <LoginView
        email={email}
        setEmail={setEmail}
        password={password}
        setPassword={setPassword}
        handleSubmit={handleSubmit}
        isLoading={isLoading}
        btnColor={btnColor}
        setBtnColor={setBtnColor}
      />
      <div>
        {authenticateRes &&
          authenticateRes.data &&
          authenticateRes.headers && (
            <Alert bsStyle={authenticateRes.data.retour ? 'success' : 'danger'}>
              <strong>
                {' '}
                {authenticateRes.data.retour
                  ? 'Authentifié'
                  : 'Non authentifié'}
              </strong>
              <strong>
                {' '}
                {authenticateRes.data.retour &&
                authenticateRes.headers.authorization
                  ? `Token AWS d'authentification: ${
                      authenticateRes.headers.authorization
                    }`
                  : ''}
              </strong>
            </Alert>
          )}

        {confidentialsRes &&
          confidentialsRes.data &&
          confidentialsRes.headers && (
            <Alert
              bsStyle={confidentialsRes.data.retour ? 'success' : 'danger'}
            >
              <strong>
                {' '}
                {confidentialsRes.data.retour
                  ? 'Confidentials OK'
                  : 'Confidentials Non OK'}
              </strong>
              <strong>
                {' '}
                {confidentialsRes.data.retour &&
                confidentialsRes.headers.authorization
                  ? `Token AWS Confidentials: ${
                      authenticateRes.headers.authorization
                    }`
                  : ''}
              </strong>
            </Alert>
          )}
      </div>
    </div>
  );
};
LoginView.propTypes = {
  classes: PropTypes.object.isRequired,
};
export default compose(
  withState('email', 'setEmail', ''),
  withState('password', 'setPassword', ''),
  withState('isLoading', 'setIsLoading', false),
  withState('btnColor', 'setBtnColor', 'primary'),
  withState('authenticateRes', 'setAuthenticateRes', ''),
  withState('confidentialsRes', 'setConfidentialsRes', ''),

  withHandlers({
    onChangeEmail: ({ setEmail }) => value => {
      setEmail(value);
    },
    handleSubmit: ({
      email,
      password,
      isLoading,
      setIsLoading,
      setBtnColor,
      setAuthenticateRes,
      setConfidentialsRes,
    }) => () => {
      setBtnColor('primary');
      setIsLoading(true);
      const authenticateUrl = `http://localhost:62463/api/authenticate/${email}/${password}`;
      axios.get(authenticateUrl).then(res => {
        setAuthenticateRes(res);
        if (res) {
          const confidentialsUrl = `http://localhost:62463/api/confidentials/${email}/`;
          axios
            .get(confidentialsUrl, {
              headers: { Authorization: res.headers.authorization },
            })
            .then(res => {
              setConfidentialsRes(res);
            });
        }
        setIsLoading(false);
      });
    },
  })
)(LoginContainer);
