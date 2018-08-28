import React from 'react';
//import { Col, Grid, Row } from 'react-bootstrap';
import NavMenu from './NavMenu';

import { Flex, WhiteSpace } from 'antd-mobile';

export default props => (

    <div className="flex-container">
        <Flex>
            <Flex.Item><NavMenu /></Flex.Item>
            {
                props.children
            }
        </Flex>
        </div>
);
