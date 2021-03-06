import React from "react";
import Joi from "joi-browser";
import Form from "./common/form";
import user from "../services/userService";

class RegisterForm extends Form {
  state = {
    data: { username: "", password: "", name: "" },
    errors: {},
    test: true,
  };

  schema = {
    username: Joi.string().required().email().label("Username"),
    password: Joi.string().required().min(5).label("Password"),
    name: Joi.string().required().label("Name"),
  };

  updateData() {}

  doSubmit = async () => {
    try {
      const response = await user.register(this.state.data);
      console.log(response);
      window.location = "/";
    } catch (ex) {
      /*if (ex.response && ex.response.status === 400) {
                const errors = { ...this.state.errors };
                errors.username = ex.response.data;
                this.setState({ errors });
            }*/

      alert("Registration unsuccessful. An account with such credentials has already been registered or an invalid email has been entered.");
    }
  };

  render() {
    return (
      <div>
        <h1>Register</h1>
        <form onSubmit={this.handleSubmit}>
          {this.renderInput("username", "Username")}
          {this.renderInput("password", "Password", "password")}
          {this.renderInput("name", "Name")}
          {this.renderButton("Register")}
        </form>
      </div>
    );
  }
}

export default RegisterForm;
