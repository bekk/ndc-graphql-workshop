import React, { useState } from 'react';
import { Query, Mutation } from 'react-apollo';
import { withRouter } from 'react-router-dom';
import { ADD_CHARACTER_TITLE, GET_CHARACTER, PUSH_CHARACTER } from './queries';

const Push = ({ name }) => {
  return (
    <Mutation mutation={PUSH_CHARACTER}>
      {pushFromWindow => <button onClick={() => pushFromWindow({ variables: { name } })}>Push</button>}
    </Mutation>
  );
};

const AddTitle = ({ name }) => {
  const [titleInput, setTitleInput] = useState('');

  return (
    <Mutation mutation={ADD_CHARACTER_TITLE}>
      {addTitle => (
        <div>
          <input
            type="text"
            value={titleInput}
            onChange={event => setTitleInput(event.currentTarget.value)}
          />
          <button
            onClick={() => {
              addTitle({ variables: { name, title: titleInput } });
              setTitleInput('');
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
    <section>
      <h1>{name}</h1>
      <p>{`isHealthy: ${isHealthy}`}</p>
      <ul>
        {titles.map(title => (
          <li>{title}</li>
        ))}
      </ul>
      <img src={image} alt="" />
      <AddTitle name={name} />
      <Push name={name} />
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
