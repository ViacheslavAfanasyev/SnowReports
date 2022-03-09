import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import styles from './App.css'

import StatesCompareReport from "./components/Report/StatesCompareReport";
import RegionsCompareReport from "./components/Report/RegionsCompareReport";


export default class App extends Component {
  static displayName = App.name;

  render () {
      return (
      <Layout>
        <Route exact path='/' component={StatesCompareReport} />
        <Route path='/states-report' component={StatesCompareReport} />
        <Route path='/regions-report' component={RegionsCompareReport} />
      </Layout>
    );
  }
}
