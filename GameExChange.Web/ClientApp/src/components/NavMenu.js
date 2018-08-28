import React from 'react';
import { Link } from 'react-router-dom';
//import { Glyphicon, Nav, Navbar, NavItem } from 'react-bootstrap';
//import { LinkContainer } from 'react-router-bootstrap';
//import './NavMenu.css';

import { Popover, NavBar, Icon } from 'antd-mobile';

import { push } from 'react-router-redux';

const Item = Popover.Item;

const myImg = src => <img src={`https://gw.alipayobjects.com/zos/rmsportal/${src}.svg`} className="am-icon am-icon-xs" alt="" />;
class App extends React.Component {
    state = {
        visible: false,
        selected: '',
        loginState: (sessionStorage.getItem('token') != null),
        headThumb: sessionStorage.getItem('headthumb'),
    };
    onSelect = (opt) => {
        //console.log(opt);
        this.setState({
            visible: false,
            selected: opt.props.value,
        });
        console.log(opt.props.value)
    };

    handleVisibleChange = (visible) => {
        this.setState({
            visible,
        });
    };
    render() {
        var overlay = [
            (<Item key="4" value="GameList" icon={myImg('tOtXhkIWzwotgGSeptou')} data-seed="logId" ><Link to="/GameList">GameList</Link></Item>),
        ];

        if (this.loginState) {
            overlay.push(
                (<Item key="5" value="Profile" icon={myImg('PKAgAqZWJVNwKsAJSmXd')} style={{ whiteSpace: 'nowrap' }}>My profile</Item>)
            )
        } else {
            overlay.push(
                (<Item key="6" value="Login" icon={myImg('uQIYTFeRrjPELImDRrPt')}><span style={{ marginRight: 5 }}>Login</span></Item>)
            )
        }

        return (<div>
            <NavBar
                mode="light"
                rightContent={
                    <Popover mask
                        overlayClassName="fortest"
                        overlayStyle={{ color: 'currentColor' }}
                        visible={this.state.visible}
                        overlay={overlay}
                        align={{
                            overflow: { adjustY: 0, adjustX: 0 },
                            offset: [-10, 0],
                        }}
                        onVisibleChange={this.handleVisibleChange}
                        onSelect={this.onSelect}
                    >
                        <div style={{
                            height: '100%',
                            padding: '0 15px',
                            marginRight: '-15px',
                            display: 'flex',
                            alignItems: 'center',
                        }}
                        >
                            <Icon type="ellipsis" />
                        </div>
                    </Popover>
                }
            >
                NavBar
      </NavBar>
        </div>);
    }
}

export default props => (<App />);
