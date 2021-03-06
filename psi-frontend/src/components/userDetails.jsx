import React from "react";
import Joi from "joi-browser";
import Form from "./common/form";
import user from "../services/userService";

class UserDetails extends Form {
    state = {
        data: { username: "", password: "", name: ""},
        errors: {},
        test: true,
    };

    schema = {
        username: Joi.string()
            .required()
            .email()
            .label("Username"),
        password: Joi.string()
            .required()
            .min(5)
            .label("Password"),
        name: Joi.string()
            .required()
            .label("Name")
    };

    doSubmit = async () => {
        try {
            const response = await user.changeDetails(this.state.data);
            console.log(response);
            alert("Account details successfully changed.");
            window.location = "/";
        } catch (ex) {
            alert("Update unsuccessful. Same details have been entered or an invalid email has been provided.");
        }
    };

    render() {
        return (
            <div className="Box_content" >
               
                <div className="container" style = {{float : "left"}}>
                     <h1>Change details</h1>
                <form onSubmit={this.handleSubmit} >
                    {this.renderInput("username", "Username")}
                    {this.renderInput("password", "Password", "password")}
                    {this.renderInput("name", "Name")}
                    {this.renderButton("Change")}
                </form>
                </div>
                </div>
        );
    }
}

export default UserDetails;