import "./App.css";
import React, { Component } from "react";
import { Route, Switch, Redirect } from "react-router-dom";
import NavBar from "./components/navBar";
import LoginForm from "./components/loginForm";
import Logout from "./components/logout";
import auth from "./services/authService";
import Receipts from "./components/receipts";
import ProtectedRoute from "./components/common/protectedRoute";
import NotFound from "./components/notFound";
import Home from "./components/Home";
import ReceiptDetails from "./components/receiptDetails";
import ReceiptForm from "./components/receiptForm";
import UserStats from "./components/userStats";
import DealPage from "./components/dealPage";
import ShoppingForm from  "./components/shoppingForm";

class App extends Component {
  state = {};

  componentDidMount() {
    const user = auth.getCurrentUser();
    this.setState({ user });
  }

  render() {
    const { user } = this.state;

    return (
      <div class = "backR" style={{ backgroundColor: "	rgb(0, 238, 234)"}}>
      <div class='container-fluid'style={{ backgroundColor: "	rgb(239, 238, 234)"}}  >
        <NavBar user={user} />
        <Switch>
          <Route path="/login" component={LoginForm} />
          <Route path="/deals" component={DealPage} />
          <Route path="/shoppingCart" component={ShoppingForm } />
          <ProtectedRoute path="/receipts/edit/:id" component={ReceiptForm} />
          <ProtectedRoute path="/receipts/:id" component={ReceiptDetails} />
          <ProtectedRoute path="/receipts" component={Receipts} />
          <ProtectedRoute path="/user-statistics" component={UserStats} />  
          <Route path="/logout" component={Logout} />
          <Route exact path="/" component={Home} />
          <Route path="/not-found" component={NotFound} />
          <Redirect to="/not-found" />
        </Switch>
        </div>
        </div>
    );
  }
}

export default App;
