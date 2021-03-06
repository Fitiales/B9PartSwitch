﻿using System;
using Xunit;
using B9PartSwitch.Fishbones.NodeDataMappers;
using B9PartSwitchTests.TestUtils.DummyTypes;

namespace B9PartSwitchTests.Fishbones.NodeDataMappers
{
    public class NodeScalarMapperBuilderTest
    {
        #region Constructor

        [Fact]
        public void TestNew()
        {
            NodeScalarMapperBuilder builder = new NodeScalarMapperBuilder("foo", typeof(DummyIConfigNode));

            Assert.Equal("foo", builder.nodeDataName);
            Assert.Same(typeof(DummyIConfigNode), builder.fieldType);
        }

        [Fact]
        public void TestNew__NullArgument()
        {
            Assert.Throws<ArgumentNullException>(() => new NodeScalarMapperBuilder(null, typeof(DummyIConfigNode)));
            Assert.Throws<ArgumentNullException>(() => new NodeScalarMapperBuilder("foo", null));
        }

        #endregion

        #region CanBuild

        [Fact]
        public void TestCanBuild__IConfigNode()
        {
            NodeScalarMapperBuilder builder = new NodeScalarMapperBuilder("foo", typeof(DummyIConfigNode));

            Assert.True(builder.CanBuild);
        }

        [Fact]
        public void TestCanBuild__IContextualNode()
        {
            NodeScalarMapperBuilder builder = new NodeScalarMapperBuilder("foo", typeof(DummyIContextualNode));

            Assert.True(builder.CanBuild);
        }

        [Fact]
        public void TestCanBuild__False()
        {
            NodeScalarMapperBuilder builder = new NodeScalarMapperBuilder("foo", typeof(DummyClass));

            Assert.False(builder.CanBuild);
        }

        #endregion

        #region Build

        [Fact]
        public void TestBuildMapper__IConfigNode()
        {
            NodeScalarMapperBuilder builder = new NodeScalarMapperBuilder("foo", typeof(DummyIConfigNode));

            NodeScalarMapper mapper = Assert.IsType<NodeScalarMapper>(builder.BuildMapper());

            Assert.Equal("foo", mapper.name);
            Assert.Same(typeof(DummyIConfigNode), mapper.fieldType);
        }

        [Fact]
        public void TestBuildMapper__IContextualNode()
        {
            NodeScalarMapperBuilder builder = new NodeScalarMapperBuilder("foo", typeof(DummyIContextualNode));

            NodeScalarMapper mapper = Assert.IsType<NodeScalarMapper>(builder.BuildMapper());

            Assert.Equal("foo", mapper.name);
            Assert.Same(typeof(DummyIContextualNode), mapper.fieldType);
        }

        [Fact]
        public void TestBuildMapper__CantBuild()
        {
            NodeScalarMapperBuilder builder = new NodeScalarMapperBuilder("foo", typeof(DummyClass));

            Assert.Throws<InvalidOperationException>(() => builder.BuildMapper());
        }

        #endregion
    }
}
