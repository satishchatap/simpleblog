import React, { Component } from "react";
import { withStyles } from "@material-ui/core/styles";
import {
  Route,
} from "react-router-dom";
import { Container } from 'reactstrap';
import Articles from "../pages/Articles";
import AllArticles from "../pages/AllArticles";
import ArticleChart from "../pages/ArticleChart";
import Article from "../pages/Article";
import { AuthCallback } from "../pages/AuthCallback";
import CreateArticle from "../pages/CreateArticle";
import Comment from "../pages/CommentArticle";
import DeleteArticle from "../pages/DeleteArticle";
import AboutUs from "../pages/AboutUs";

import PrivacyPolicy from "../pages/PrivacyPolicy";


const styles = theme => ({
  toolbar: theme.mixins.toolbar,
  title: {
    flexGrow: 1,
    backgroundColor: theme.palette.background.default,
    padding: theme.spacing(3),
  },
  content: {
    flexGrow: 1,
    padding: theme.spacing(3),
  },
  fullWidth: {
    width: '100%',
  },
  root: {
    flexGrow: 1,
  },
  paper: {
    padding: theme.spacing(1),
    textAlign: 'center',
    color: theme.palette.text.secondary,
  },
  table: {
    minWidth: 650,
  },
});

class MainContent extends Component {
 
  render() {
    return (
      <Container>
          <Route
            exact
            path="/CreateArticle"
            render={() => {
              return <CreateArticle openIdManager={this.props.openIdManager} />;
            }}
          />
          <Route
            exact
            path="/CreateArticle/:articleId"
            render={() => {
              return <CreateArticle openIdManager={this.props.openIdManager} />;
            }}
          />
          <Route
            exact
            path="/myarticles"
            render={() => {
              return <Articles openIdManager={this.props.openIdManager} />;
            }}
          />
          <Route
            exact
            path="/allarticles"
            render={() => {
              return <AllArticles openIdManager={this.props.openIdManager} />;
            }}
          />
          <Route
            exact
            path="/"
            render={() => {
              return <ArticleChart openIdManager={this.props.openIdManager} />;
            }}
          />
          <Route
            exact
            path="/articles/:articleId/delete"
            render={() => {
              return <DeleteArticle openIdManager={this.props.openIdManager} />;
            }}
          />
          <Route
            exact
            path="/articles/:articleId/comment"
            render={() => {
              return <Comment openIdManager={this.props.openIdManager} />;
            }}
          />
          <Route
            exact
            path="/articles/:articleId"
            render={() => {
              return <Article openIdManager={this.props.openIdManager} />;
            }}
          />
          <Route
            exact
            path="/privacypolicy"
            render={() => {
              return <PrivacyPolicy/>;
            }}
          />
          <Route
            exact
            path="/aboutus"
            render={() => {
              return <AboutUs/>;
            }}
          />
          <Route
            path="/callback"
            render={() => {
              return <AuthCallback />;
            }}
          />
        </Container>
    )
  }
}

export default withStyles(styles, { withTheme: true })(MainContent);