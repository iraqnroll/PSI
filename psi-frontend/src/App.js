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
import RegisterForm from "./components/registerForm";
import ReceiptForm from "./components/receiptForm";
import UserStats from "./components/userStats";
import PriceHistory from "./components/priceHistory";
import UserDetails from "./components/userDetails";
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
      <div className="Box_content">
        <NavBar user={user} />
        <Switch>
          <Route path="/register" component={RegisterForm} />
          <Route path="/change" component={UserDetails} />
          <Route path="/login" component={LoginForm} />
          <ProtectedRoute path="/deals" component={DealPage} />
          <ProtectedRoute path="/shoppingCart" component={ShoppingForm } />
          <ProtectedRoute path="/receipts/edit/:id" component={ReceiptForm} />
          <ProtectedRoute path="/receipts/:id" component={ReceiptDetails} />
          <ProtectedRoute path="/receipts" component={Receipts} />
          <ProtectedRoute path="/user-statistics" component={UserStats} />
          <ProtectedRoute path="/item-history" component={PriceHistory} />
          <Route path="/logout" component={Logout} />
          <Route exact path="/" component={Home} />
          <Route path="/not-found" component={NotFound} />
          <Redirect to="/not-found" />
        </Switch>
      </div>
    );
  }
}

export default App;
