import React from "react";

const Input = ({ name, label, error, test, ...rest }) => {
  return (
    <div className="form-group">
      {test && <label htmlFor={name}>{label}</label>}
      <input {...rest} name={name} id={name} className="form-control" />
      {error && <div className="alert alert-danger">{error}</div>}
    </div>
  );
};

export default Input;
