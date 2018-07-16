import React, { Component } from 'react';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';
import { Link } from 'react-router-dom';

import { actionCreators } from '../store/GameListStore';

import './css/GameList.css';

class GameList extends Component {
    componentWillMount() {
        // This method runs when the component is first added to the page
        const pageIndex = parseInt(this.props.match.params.pageIndex, 10) || 0;
        this.props.requestGameDatas(pageIndex);
    }

    componentWillReceiveProps(nextProps) {
        // This method runs when incoming props (e.g., route params) change
        const pageIndex = parseInt(nextProps.match.params.pageIndex, 10) || 0;
        this.props.requestGameDatas(pageIndex);

    }

    render() {
        return (
            <div>
                <h1>Game List</h1>
                <p>It`s a Game List</p>
                {renderGameTable(this.props)}
            </div>
        );
    }
}

function renderGameTable(props) {
    console.log(props.results);
    return (
      
        <table className='table'>
            <thead>
                <tr>
                    <th>Name</th>
                    <th>Type</th>
                    <th>Left</th>
                    <th></th>
                </tr>
            </thead>
            <tbody>
                {
                    props.results.map(obj =>
                        <tr key={obj.id}>
                            <td>{obj.gameName}</td>
                            <td>{obj.gameType}</td>
                            <td>{obj.holdNum - obj.exchangedNum}</td>
                            <td>
                                <a className={"cur_p " + ((obj.holdNum - obj.exchangedNum) <= 0 ? '' : 'disabled')}
                                    to={`/GameDetail/${obj.id}`}
                                    >交换</a>
                                &nbsp;&nbsp;
                                <a className={"cur_p " + ((obj.holdNum - obj.exchangedNum) > 0 ? '' : 'disabled')}
                                    to={`/GameDetail/${obj.id}`}
                                    >借入</a>
                            </td>
                        </tr>
                    )
                }
            </tbody>
        </table>
    );
}



//function renderPagination(props) {
//    const prevStartDateIndex = (props.startDateIndex || 0) - 5;
//    const nextStartDateIndex = (props.startDateIndex || 0) + 5;

//    return <p className='clearfix text-center'>
//        <Link className='btn btn-default pull-left' to={`/fetchdata/${prevStartDateIndex}`}>Previous</Link>
//        <Link className='btn btn-default pull-right' to={`/fetchdata/${nextStartDateIndex}`}>Next</Link>
//        {props.isLoading ? <span>Loading...</span> : []}
//    </p>;
//}

export default connect(
    state => state.gameListStore,
    dispatch => bindActionCreators(actionCreators, dispatch)
)(GameList);

