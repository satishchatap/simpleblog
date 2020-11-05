import React, { } from "react";
import articlesService from "../store/articlesService";
import { withRouter } from "react-router";
import PageBase from "../components/PageBase";
import { Link } from "react-router-dom";
import Button from "@material-ui/core/Button";
import TextField from "@material-ui/core/TextField";
import { grey } from "@material-ui/core/colors";

class CreateArticle extends React.Component {

  static displayName = CreateArticle.name;

  constructor(props) {
    super(props);
    this.state = {
      id: null,
      title: "",
      summary: "",
      body: "",
      submitted: false
    }

    this.handleInputChange = this.handleInputChange.bind(this);
    this.saveArticle = this.saveArticle.bind(this);
    this.newArticle = this.newArticle.bind(this);
    if(this.props.match.params.articleId!==undefined)
    {
      this.fetchData(this.props.match.params.articleId);
    }
  }

  fetchData = id => {
    this.props.openIdManager.getUser().then((user) => {
      if (user) {
        articlesService
          .getArticle(user, id)
          .then((response) => {
            this.setState(response.data.article);
            console.log(response.data);            
          })
          .catch((e) => {
            console.log(e);
          });
      }
    });
  };

  handleInputChange = event => {
    const { name, value } = event.target;
    this.setState(
      () => {
        return {
          [name]: value
        };
      })
  };

  saveArticle = () => {
    this.props.openIdManager.getUser().then((user) => {
      if (user) {
        var bodyFormData = new FormData();
        bodyFormData.append('title', this.state.title);
        bodyFormData.append('summary', this.state.summary);
        bodyFormData.append('body', this.state.body);

        articlesService
          .createArticle(user, bodyFormData)
          .then(response => {
            this.setState({
              id: response.data.article.articleId,
              title: response.data.article.title,
              summary: response.data.article.summary,
              body: response.data.article.body,
              publishdate: response.data.article.publishdate,
              submitted: true
            });
          })
          .catch(e => {
            console.log(e);
          });
      }
    })
  };

  newArticle = () => {
    this.setState({
      id: null,
      title: "",
      summary: "",
      body: "",
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

      <PageBase title="Create a New Article" navigation="My Articles / Create a New Article">

        {this.state.submitted ? (
          <div>
              <div style={styles.buttons}>
                <Button
                  style={styles.saveButton}
                  variant="contained"
                  type="submit"
                  color="primary"
                  onClick={this.newArticle}
                >
                  Another one
                  </Button>
              </div>
          </div>
        ) : (
            <div>

              <TextField
                hintText="Title"
                label="Title"
                fullWidth={true}
                margin="normal"
                value={this.state.title}
                onChange={this.handleInputChange}
                name="title"
                id="title"
                required
              />

              <TextField
                hintText="Summary"
                label="Summary"
                fullWidth={true}
                margin="normal"
                value={this.state.summary}
                onChange={this.handleInputChange}
                name="summary"
                id="summary"
                required
              />

              <TextField
                hintText="Content"
                label="Content"
                fullWidth={true}
                margin="normal"
                value={this.state.body}
                onChange={this.handleInputChange}
                name="body"
                id="body"
                required
              />

              <div style={styles.buttons}>
                <Link to="/">
                  <Button variant="contained">Cancel</Button>
                </Link>

                <Button
                  style={styles.saveButton}
                  variant="contained"
                  type="submit"
                  color="primary"
                  onClick={this.saveArticle}
                >
                  Save
                  </Button>
              </div>

            </div>

          )}
      </PageBase>
    );
  }
}

export default withRouter(CreateArticle);