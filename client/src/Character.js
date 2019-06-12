import React, { useState } from 'react';
import { Query, Mutation } from 'react-apollo';
import { withRouter } from 'react-router-dom';
import { ADD_CHARACTER_TITLE, GET_CHARACTER, PUSH_CHARACTER } from './queries';

const Push = ({ name }) => {
  return (
    <Mutation mutation={PUSH_CHARACTER}>
      {pushFromWindow => (
        <button
          onClick={() => {
            pushFromWindow({ variables: { name } });
            window.location.reload();
          }}
        >
          Push
        </button>
      )}
    </Mutation>
  );
};

const AddTitle = ({ name }) => {
  const [titleInput, setTitleInput] = useState('');

  return (
    <Mutation mutation={ADD_CHARACTER_TITLE}>
      {addTitle => (
        <div>
          <input type="text" value={titleInput} onChange={event => setTitleInput(event.currentTarget.value)} />
          <button
            onClick={() => {
              addTitle({ variables: { name, title: titleInput } });
              window.location.reload();
            }}
          >
            Add title
          </button>
        </div>
      )}
    </Mutation>
  );
};

const View = ({ character }) => {
  const { name, image, titles, isHealthy } = character;

  return (
    <section className="character">
      <h1>{name}</h1>
      <div className="character-info">
        <div className="character-image">
          <img src={image} alt="" className="image-large" />
          {!isHealthy && <div className="hurt">IS HURTING</div>}
        </div>
        <div className="characteristics">
          <strong>Titles</strong>
          <ul>
            {titles.map(title => (
              <li>{title}</li>
            ))}
          </ul>
        </div>
      </div>
      <div className="character-actions">
        <AddTitle name={name} />
        <Push name={name} />
      </div>
    </section>
  );
};

class Character extends React.Component {
  render() {
    const paramName = this.props.match.params.name;

    return (
      <Query query={GET_CHARACTER} variables={{ name: paramName }}>
        {({ loading, error, data }) => {
          if (loading) {
            return <h1>Laster...</h1>;
          }

          if (error) {
            return <h1>Error!</h1>;
          }

          return <View character={data.character} />;
        }}
      </Query>
    );
  }
}

export default withRouter(Character);
