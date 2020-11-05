import React, { } from "react";
import articlesService from "../store/articlesService";
import { withRouter } from "react-router";
import PageBase from "../components/PageBase";
import { Link } from "react-router-dom";
import Button from "@material-ui/core/Button";
import { grey } from "@material-ui/core/colors";

class DeleteArticle extends React.Component {

  static displayName = DeleteArticle.name;

  constructor(props) {
    super(props);
    this.state = {
      articleId: this.props.match.params.articleId,
      submitted: false
    }

    this.handleInputChange = this.handleInputChange.bind(this);
    this.saveDeleteArticle = this.saveDeleteArticle.bind(this);
    this.newDeleteArticle = this.newDeleteArticle.bind(this);
  }

  handleInputChange = event => {
    const { name, value } = event.target;
    this.setState(
      () => {
        return {
          [name]: value
        };
      })
  };

  saveDeleteArticle = () => {
    this.props.openIdManager.getUser().then((user) => {
      if (user) {
        articlesService
          .deleteArticle(user, this.state.articleId)
          .then(response => {
            this.setState({
              articleId: response.data.articleId,
              submitted: true
            });
          })
          .catch(e => {
            console.log(e);
          });
      }
    })
  };

  newDeleteArticle = () => {
    this.setState({
      articleId: this.props.match.params.articleId,
      submitted: false
    });
  };

  render() {

    const styles = {
      toggleDiv: {
        marginTop: 20,
        marginBottom: 5
      },
      toggleLabel: {
        color: grey[400],
        fontWeight: 100
      },
      buttons: {
        marginTop: 30,
        float: "right"
      },
      saveButton: {
        marginLeft: 5
      }
    };

    return (

      <PageBase title="Delete Article" navigation="My Articles / Delete Article">

        {this.state.submitted ? (
          <div>
            <div style={styles.buttons}>
              <Button
                style={styles.saveButton}
                variant="contained"
                type="submit"
                color="primary"
                onClick={this.newDeleteArticle}
              >
                Another one
                  </Button>
            </div>
          </div>
        ) : (
            <div style={styles.buttons}>
              <Link to="/">
                <Button variant="contained">Cancel</Button>
              </Link>

              <Button
                style={styles.saveButton}
                variant="contained"
                type="submit"
                color="primary"
                onClick={this.saveDeleteArticle}
              >
                Save
                      </Button>
            </div>
          )}

      </PageBase>
    );
  }
}

export default withRouter(DeleteArticle);