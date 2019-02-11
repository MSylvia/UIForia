﻿﻿using UIForia;
using NUnit.Framework;
using Tests.Mocks;
using UIForia.Parsing;
using UnityEngine;

[TestFixture]
public class TemplateParsingTests {

    [Template("Tests/Templates/Parsing/Test1.xml")]
    private class Test1 : UIElement { }

    [Template(TemplateType.String, @"
    <UITemplate>
        <Contents>
            <ThingWithSlot>
                <SlotContent name='ThingWithSlot.Slot0'>
                    <Text x-id='contents'>should be slot child</Text>
                </SlotContent>
            </ThingWithSlot>
        </Contents>
    </UITemplate>
    ")]
    private class TestThing2 : UIElement { }

    [Template(TemplateType.String, @"
    <UITemplate>
        <Contents>
            <ThingWithSlot/>
        </Contents>
    </UITemplate>
    ")]
    private class TestThing3 : UIElement { }
    
    [Template(TemplateType.String, @"
    <UITemplate>
        <Contents>
           <Slot name='ThingWithSlot.Slot0'>
                <Text>default content</Text>
           </Slot>
        </Contents>
    </UITemplate>
    ")]
    private class ThingWithSlot : UIElement { }

    [Test]
    public void Children_ParsesCorrectly() {
        ParsedTemplate parsedTemplate = TemplateParser.ParseTemplateFromString<Test1>(@"
            <UITemplate>
                <Contents>
                    <Children/>
                </Contents>
            </UITemplate>
        ");
        Assert.IsInstanceOf<UIChildrenTemplate>(parsedTemplate.childTemplates[0]);
    }

    [Test]
    public void Children_CannotAppearInsideRepeat() {
        var x = Assert.Throws<InvalidTemplateException>(() => {
            TemplateParser.ParseTemplateFromString<Test1>(@"
                <UITemplate>
                    <Contents>
                        <Repeat list='{null}'>
                            <Children/>
                        </Repeat>
                    </Contents>
                </UITemplate>
            ");
        });
        Assert.AreEqual("<Children> cannot be inside <Repeat>", x.Message);
    }

    [Test]
    public void Children_MustBeEmpty() {
        var x = Assert.Throws<InvalidTemplateException>(() => {
            TemplateParser.ParseTemplateFromString<Test1>(@"
                <UITemplate>
                    <Contents>
                            <Children>text</Children>
                    </Contents>
                </UITemplate>
            ");
        });
        Assert.AreEqual("<Children> tags cannot have children", x.Message);
    }

    [Test]
    public void Switch_CanOnlyContainCaseAndDefault() {
        var x = Assert.Throws<InvalidTemplateException>(() => {
            TemplateParser.ParseTemplateFromString<Test1>(@"
                <UITemplate>
                    <Contents>
                        <Switch value='1'>
                            text                                        
                        </Switch>
                    </Contents>
                </UITemplate>
            ");
        });
        Assert.AreEqual("<Switch> can only contain <Case> and <Default> elements", x.Message);
    }

    [Test]
    public void Switch_CanOnlyContainOneDefault() {
        var x = Assert.Throws<InvalidTemplateException>(() => {
            TemplateParser.ParseTemplateFromString<Test1>(@"
                <UITemplate>
                    <Contents>
                        <Switch value='1'>
                            <Default>text1</Default>                                        
                            <Default>text2</Default>                                        
                        </Switch>
                    </Contents>
                </UITemplate>
            ");
        });
        Assert.AreEqual("<Switch> can only contain one <Default> element", x.Message);
    }

    [Test]
    public void Switch_CanContainOnlyCases() {
        Assert.DoesNotThrow(() => {
            TemplateParser.ParseTemplateFromString<Test1>(@"
                <UITemplate>
                    <Contents>
                        <Switch value='1'>
                            <Case when='1'>text1</Case>                                        
                            <Case when='2'>text2</Case>                                        
                        </Switch>
                    </Contents>
                </UITemplate>
            ");
        });
    }

    [Test]
    public void Switch_CanContainOnlyDefault() {
        Assert.DoesNotThrow(() => {
            TemplateParser.ParseTemplateFromString<Test1>(@"
                <UITemplate>
                    <Contents>
                        <Switch value='1'>
                            <Default>text1</Default>                                        
                        </Switch>
                    </Contents>
                </UITemplate>
            ");
        });
    }

    [Test]
    public void Switch_CannotBeEmpty() {
        var x = Assert.Throws<InvalidTemplateException>(() => {
            TemplateParser.ParseTemplateFromString<Test1>(@"
                <UITemplate>
                    <Contents>
                        <Switch value='1'>
                                                                  
                        </Switch>
                    </Contents>
                </UITemplate>
            ");
        });
        Assert.AreEqual("<Switch> cannot be empty", x.Message);
    }

    [Test]
    public void Case_MustHaveWhenAttribute() {
        var x = Assert.Throws<InvalidTemplateException>(() => {
            TemplateParser.ParseTemplateFromString<Test1>(@"
                <UITemplate>
                    <Contents>
                        <Switch value='1'>
                            <Case>text1</Case>                                        
                            <Case when='2'>text2</Case>                                        
                        </Switch>
                    </Contents>
                </UITemplate>
            ");
        });
        Assert.AreEqual("<Case> is missing required attribute 'when'", x.Message);
    }

//    [Test]
//    public void Prefab_MustBeEmpty() {
//        var x = Assert.Throws<InvalidTemplateException>(() => {
//            TemplateParser.ParseTemplateFromString<Test1>(@"
//                <UITemplate>
//                    <Contents>
//                            <Prefab>text</Prefab>
//                    </Contents>
//                </UITemplate>
//            ");
//        });
//        Assert.AreEqual("<Prefab> tags cannot have children", x.Message);
//    }

    [Test]
    public void Text_Parses() {
        Assert.DoesNotThrow(() => {
            TemplateParser.ParseTemplateFromString<Test1>(@"
                <UITemplate>
                    <Contents>
                            <Group>text</Group>
                    </Contents>
                </UITemplate>
            ");
        });
    }

    [Test]
    public void Text_AssignsRawString() {
        ParsedTemplate parsedTemplate = TemplateParser.ParseTemplateFromString<Test1>(@"
                <UITemplate>
                    <Contents>
                            <Group>text {value} is here</Group>
                    </Contents>
                </UITemplate>
            ");
        UITextTemplate template = (UITextTemplate) parsedTemplate.childTemplates[0].childTemplates[0];
        Assert.IsNotNull(template);
        Assert.AreEqual("'text {value} is here'", template.RawText);
    }

    [Test]
    public void Repeat_CanNest() {
        Assert.DoesNotThrow(() => {
            TemplateParser.ParseTemplateFromString<Test1>(@"
                <UITemplate>
                    <Contents>
                       <Repeat list='{something}'>
                            <Repeat list='{other}' as='thing'>
                                <Group>text</Group>                            
                            </Repeat>
                        </Repeat>
                    </Contents>
                </UITemplate>
            ");
        });
    }

    [Test]
    public void Slot_CanParse() {
        ParsedTemplate parsedTemplate = TemplateParser.ParseTemplateFromString<Test1>(@"
                <UITemplate>
                    <Contents>
                        <Group>
                            <Slot name=""slot0""/>
                        </Group>
                    </Contents>
                </UITemplate>
            ");
        Assert.IsNotNull(parsedTemplate);
    }

    [Test]
    public void SlotContent_CanParse() {
        ParsedTemplate parsedTemplate = TemplateParser.ParseTemplateFromString<Test1>(@"
                <UITemplate>
                    <Contents>
                        <Thing>
                            <SlotContent name=""slot0""/>
                        </Thing>
                    </Contents>
                </UITemplate>
            ");
        Assert.IsNotNull(parsedTemplate);
    }

    [Test]
    public void SlotContent_UsesAssignedSlotContentOnMatch() {
        MockApplication app = new MockApplication(typeof(TestThing2));
        app.SetViewportRect(new Rect(0, 0, 1000f, 1000f));
        ThingWithSlot slotThing = app.RootElement.FindFirstByType<ThingWithSlot>();
        UITextElement textElement = slotThing.FindFirstByType<UITextElement>();
        Assert.IsNotNull(textElement);
        Assert.AreEqual("should be slot child", textElement.text);
    }
    
    [Test]
    public void SlotContent_UsesDefaultSlotContentOnNoMatch() {
        MockApplication app = new MockApplication(typeof(TestThing3));
        app.SetViewportRect(new Rect(0, 0, 1000f, 1000f));
        ThingWithSlot slotThing = app.RootElement.FindFirstByType<ThingWithSlot>();
        UITextElement textElement = slotThing.FindFirstByType<UITextElement>();
        Assert.IsNotNull(textElement);
        Assert.AreEqual("default content", textElement.text);
    }

    [Test]
    public void Text_ParsesExpressionParts() {
        TextElementParser parser = new TextElementParser();
        string[] output1 = parser.Parse("'one expression'");
        Assert.AreEqual(1, output1.Length);
        Assert.AreEqual("'one expression'", output1[0]);

        string[] output2 = parser.Parse("'two {expressions}'");
        Assert.AreEqual(2, output2.Length);
        Assert.AreEqual("'two '", output2[0]);
        Assert.AreEqual("{expressions}", output2[1]);

        string[] output3 = parser.Parse("'three {expressions} here'");
        Assert.AreEqual(3, output3.Length);
        Assert.AreEqual("'three '", output3[0]);
        Assert.AreEqual("{expressions}", output3[1]);
        Assert.AreEqual("' here'", output3[2]);
    }

}