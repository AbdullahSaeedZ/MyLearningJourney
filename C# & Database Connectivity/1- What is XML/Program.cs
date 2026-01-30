/* DEEPER LOOK INTO MARKUP (DESCRIPTIVE/DECLARATIVE) LANGUAGES:
   
   1. PHILOSOPHY OF "WHAT" VS "HOW":
      - Markup is Declarative: You declare the final state (e.g., "This text is a header").
      - You don't tell the computer the steps to render pixels; you just label the content.
      
   2. THE ROLE OF THE PARSER:
      - Markup cannot execute itself. It needs a "Parser" (like a Browser for HTML 
        or the XAML engine in .NET).
      - The Parser reads the hierarchy and translates your description into objects.

   3. STRUCTURAL HIERARCHY (Tree Structure):
      - Markup excels at representing nested relationships (Parent-Child).
      - Example: A <Section> contains a <Paragraph>, which contains <Bold> text.
   
   4. DATA VS. BEHAVIOR:
      - Markup = Static Data/Structure (The Skeleton).
      - Programming = Dynamic Behavior/Logic (The Muscles/Brain).
      
   EXAMPLES IN YOUR .NET JOURNEY:
   - HTML: Describes the structure of web pages.
   - XML/JSON: Describes data exchange and configurations.
   - XAML: Describes the UI components in WPF/MAUI.
*/

// QUICK COMPARISON SUMMARY:
// -----------------------------------------------------------
// | Feature      | Markup (Descriptive) | Programming (Logic) |
// |--------------|----------------------|--------------------|
// | Execution    | Interpreted/Parsed   | Compiled/Executed  |
// | Control Flow | None (No loops/ifs)  | Full (Loops/Conds) |
// | Purpose      | Organization         | Manipulation       |
// -----------------------------------------------------------

// eXtensible = can extend and define tags and structure as i need, unlike HTML which has pre-defined tags.

https://www.notion.so/What-is-XML-2e2ef085e0d180a18c21c0a7a524db07

https://www.youtube.com/watch?v=3WLKXzTCWEs