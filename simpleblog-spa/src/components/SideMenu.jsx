import React, { Component } from "react";
import Drawer from "@material-ui/core/Drawer";
import List from "@material-ui/core/List";
import ListItem from "@material-ui/core/ListItem";
import ListItemIcon from "@material-ui/core/ListItemIcon";
import ListItemText from "@material-ui/core/ListItemText";
import AccountBalanceIcon from '@material-ui/icons/AccountBalance';
import ExitToApp from "@material-ui/icons/ExitToApp";
import AddIcon from '@material-ui/icons/Add';
import { Avatar } from "@material-ui/core";
import { withStyles } from "@material-ui/core/styles";
import classNames from "classnames";
import { fade } from "@material-ui/core/styles/colorManipulator";
import InfoIcon from '@material-ui/icons/Info';
import SecurityIcon from '@material-ui/icons/Security';
import HomeIcon from '@material-ui/icons/Home';

import AccountCircle from "@material-ui/icons/AccountCircle";
import LibraryBooksIcon from '@material-ui/icons/LibraryBooks';
const drawStyles = theme => {
  return {
    drawerPaper: {
      width: theme.drawer.width,
      backgroundColor: "rgb(33, 33, 33)",
      color: "white",
      borderRight: "0px",
      boxShadow: "rgba(0, 0, 0, 0.16) 0px 3px 10px, rgba(0, 0, 0, 0.23) 0px 3px 10px"
    },
    drawerPaperClose: {
      overflowX: "hidden",
      transition: theme.transitions.create("width", {
        easing: theme.transitions.easing.sharp,
        duration: theme.transitions.duration.leavingScreen
      }),
      width: theme.drawer.miniWidth
    },
    logo: {
      cursor: "pointer",
      fontSize: 22,
      color: "white",
      lineHeight: "64px",
      fontWeight: 300,
      backgroundColor: theme.palette.primary[500],
      paddingLeft: 15,
      height: 64
    },
    avatarRoot: {
      padding: "16px 0 10px 15px",
      backgroundImage: "url(" + require("../images/material_bg.png") + ")",
      height: 100,
      display: "flex"
    },
    avatarRootMini: {
      padding: "15px 0 10px 10px"
    },
    avatarIcon: {
      float: "left",
      display: "block",
      boxShadow: "0px 0px 0px 8px rgba(0,0,0,0.2)"
    },
    avatarSpan: {
      paddingTop: 8,
      paddingLeft: 24,
      display: "block",
      color: "white",
      fontWeight: 300,
      textShadow: "1px 1px #444"
    },
    homeItem: {
      color: "white",
      fontSize: 14
    },
    chevronIcon: {
      float: "right",
      marginLeft: "auto"
    },
    subMenus: {
      paddingLeft: 20
    },
    popupSubMenus: {
      backgroundColor: "rgb(33, 33, 33)",
      color: "white",
      boxShadow: "rgba(0, 0, 0, 0.16) 0px 3px 10px, rgba(0, 0, 0, 0.23) 0px 3px 10px"
    },
    menuItem: {
      padding: "10px 16px",
      color: "white",
      fontSize: 14,
      "&:focus": {
        backgroundColor: theme.palette.primary.main,
        "& .MuiListItemIcon-root, & .MuiListItemText-primary": {
          color: theme.palette.common.white
        }
      }
    },
    miniMenuItem: {
      color: "white",
      margin: "10px 0",
      fontSize: 14,
      "&:focus": {
        backgroundColor: theme.palette.primary.main,
        "& .MuiListItemIcon-root, & .MuiListItemText-primary": {
          color: theme.palette.common.white
        }
      }
    },
    miniIcon: {
      margin: "0 auto",
      color: "white",
      "&:hover": {
        backgroundColor: fade(theme.palette.common.white, 0.5)
      },
      minWidth: "24px"
    }
  };
};

class SideMenu extends Component {
  constructor(props) {
    super(props);
    this.state = {
      isLoggedIn: false,
      user: null
    }

    this.performLogin = this.performLogin.bind(this);
    this.performLogout = this.performLogout.bind(this);
  }

  componentDidMount() {
    this.props.openIdManager.getUser().then((user) => {
      if (user) {
        this.setState({ isLoggedIn: true, user: user });
      } else {
        this.setState({ isLoggedIn: false, user: null });
      }
    });
  }

  render() {
    const { user } = this.state;
    const { classes, navDrawerCreate,navDrawerOpen, handleChangeNavDrawer } = this.props;
    return (
      <div>
        <Drawer
          open={navDrawerOpen}
          variant="permanent"
          classes={{
            paper: classNames(classes.drawerPaper, !navDrawerOpen && classes.drawerPaperClose)
          }}
        >

          <div>
            <div className={classes.logo} onClick={handleChangeNavDrawer}>SB</div>
            {this.state.isLoggedIn && <div className={classNames(classes.avatarRoot, !navDrawerCreate && classes.avatarRootMini)}>
              <Avatar size={navDrawerCreate ? 48 : 32} classes={{ root: classes.avatarIcon }} />
              <span className={classes.avatarSpan}>{user.profile.name}</span>
            </div>}
            <List>
              {this.state.isLoggedIn ? this.renderWhenTrue() : this.renderWhenFalse()}
            </List>
          </div>

        </Drawer>
      </div>
    );
  }
  
  renderWhenTrue() {
    const { user } = this.state;
    let full_access =user.scope!== undefined ? user.scope.indexOf("api1.full_access")>= 0 : false;
    
    return (
      <React.Fragment>

        <ListItem button component="a" href="/">
          <ListItemIcon style={{ color: "white" }}>
            <HomeIcon />
          </ListItemIcon>
          <ListItemText primary="Articles Stats" />
        </ListItem>

        <ListItem button component="a" href="/allarticles">
          <ListItemIcon style={{ color: "white" }}>
            <LibraryBooksIcon />
          </ListItemIcon>
          <ListItemText primary="All Articles" />
        </ListItem>
         {full_access &&
        <ListItem button component="a" href="/myarticles">
          <ListItemIcon style={{ color: "white" }}>
            <AccountBalanceIcon />
          </ListItemIcon>
          <ListItemText primary="My Articles" />
        </ListItem>}
          {full_access &&
        <ListItem button component="a" href="/CreateArticle" >
          <ListItemIcon style={{ color: "white" }}>
            <AddIcon />
          </ListItemIcon>
          <ListItemText primary="Create an Article" />
        </ListItem>
  }
        
        <ListItem  button component="a" href="/aboutus">
          <ListItemIcon  style={{ color: "white" }}>
            <InfoIcon />
          </ListItemIcon>
          <ListItemText primary="About Us"/>
        </ListItem>
        
        <ListItem  button component="a" href="/privacypolicy" >
          <ListItemIcon  style={{ color: "white" }}>
            <SecurityIcon />
          </ListItemIcon>
          <ListItemText primary="Privacy Policy"/>
        </ListItem>
        <ListItem button>
          <ListItemIcon style={{ color: "white" }}  onClick={this.performLogout} >
            <ExitToApp />
          </ListItemIcon>
          <ListItemText primary="Sign Out" onClick={this.performLogout} />
        </ListItem>
      </React.Fragment>
    )
  }

  renderWhenFalse() {
    return (
      <React.Fragment>
        
        <ListItem  button component="a" href="/aboutus">
          <ListItemIcon  style={{ color: "white" }}>
            <InfoIcon />
          </ListItemIcon>
          <ListItemText primary="About Us"/>
        </ListItem>
        
        <ListItem  button component="a" href="/privacypolicy" >
          <ListItemIcon  style={{ color: "white" }}>
            <SecurityIcon />
          </ListItemIcon>
          <ListItemText primary="Privacy Policy"/>
        </ListItem>
        
        <ListItem button>
          <ListItemIcon style={{ color: "white" }}  onClick={this.performLogin} >
            <AccountCircle />
          </ListItemIcon>
          <ListItemText primary="SignIn" onClick={this.performLogin} />
        </ListItem>
      </React.Fragment>
    )
  }

  performLogin() {
    console.log('signIncalled...');
    this.props.openIdManager.signinRedirect();
  }

  performLogout() {
    console.log('signOutcalled...');
    this.props.openIdManager.signoutRedirect();
  }
}

export default withStyles(drawStyles, { withTheme: true })(SideMenu);