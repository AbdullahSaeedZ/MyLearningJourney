/*============================================================================
                                       RECAP
  ============================================================================
 
  PHASE 1: THE SINGLE-TASK ERA
  ----------------------------------------------------------------------------
  In the beginning, a single running program took absolute control over the CPU. 
  Every other system task was entirely blocked and frozen until that program finished.
 
  PHASE 2: THE MULTI-TASKING ERA (THE PROCESS)
  ----------------------------------------------------------------------------
  The "Process" was introduced to allow multiple different programs to run together. 
  It simulated simultaneous execution via ultra-fast Context Switching, providing 
  each program with a completely isolated, secure memory container.
 
  PHASE 3: THE INTRA-PROGRAM ERA (THE THREAD)
  ----------------------------------------------------------------------------
  The "Thread" was invented to split a single isolated Process internally. 
  This allowed a single application to execute multiple internal tasks concurrently 
  (like handling UI and downloading files) without wasting RAM on new processes.
 
  NOTE ON SINGLE-CORE HARDWARE:
  There is NO real parallelism in a single-core CPU. It is purely a simulation 
  called "Concurrency", achieved entirely through ultra-fast context switching.
 



  ============================================================================
          THE HISTORICAL MISCONCEPTION: MULTI-THREADING VS. MULTI-CORE
  ============================================================================
  A common misconception is that Multi-threading was invented only after Multi-Core 
  CPUs were created. This is historically inaccurate:
 
  - Multi-threading was introduced EARLY in software to achieve CONCURRENCY on 
    single-core systems (simulating simultaneous tasks via fast context-switching).

  - Multi-Core CPUs came LATER to upgrade multi-threading from simulated 
    concurrency into TRUE PARALLELISM (executing tasks physically at the same time).
 


  ============================================================================
                  INTRODUCTION TO MULTI-THREADING (WHAT & WHY)
  ============================================================================
 
  WHAT IS MULTI-THREADING?
  ----------------------------------------------------------------------------
  Multi-threading is a software development technique where a developer explicitly 
  codes an application to split its workload across multiple independent threads. 
 
  WHY DO WE USE IT?
  ----------------------------------------------------------------------------
  1. Responsiveness (Asynchrony): It prevents heavy operations (like downloading 
     or querying a database) from freezing the user interface (UI Thread).

  2. Performance (Throughput): It allows a software program to fully exploit 
     modern underlying processor hardware rather than leaving available cores idle.
 



  ============================================================================
                     MODERN HARDWARE: MULTI-CORE ARCHITECTURE
  ============================================================================
 
  1. MULTI-CORE EVOLUTION
  ----------------------------------------------------------------------------
  As hardware engineering advanced, chip makers stopped trying to just make 
  single cores faster due to physical heat limits. Instead, they packed multiple 
  independent cores onto a single CPU die (e.g., modern Intel/AMD chips with 8+ cores).
 
  This hardware evolution completely transformed how software executes.
 
  2. CONCURRENCY VS. TRUE PARALLELISM
  ----------------------------------------------------------------------------
  With multi-core processors, operating systems transitioned from merely simulating 
  simultaneous execution (Concurrency) to executing tasks truly simultaneously 
  at the exact same physical instant (True Parallelism).
 
  How it functions at the hardware level:
  - The OS scheduler assigns Thread 1 of your application directly to Core 1.
  - At the exact same femtosecond, the OS routes Thread 2 of that same app to Core 2.
 
  Both threads run physically, mathematically, and concurrently with absolutely 
  zero time-slicing or waiting required.
 



  ============================================================================
             REAL-WORLD EXAMPLES OF MULTI-THREADED APPLICATIONS
  ============================================================================
  Modern software relies heavily on multi-threading to remain fast and responsive.
 
  1. Web Browsers (Chrome, Edge, Firefox)
  ----------------------------------------------------------------------------
  - Main (UI) Thread: Renders the webpage, handles your scrolling and clicks.
  - Worker Threads: Fetch images, run JavaScript engines, and download files 
    in the background without freezing your screen.
 
  2. Video Games (e.g., Cyberpunk 2077, GTA V)
  ----------------------------------------------------------------------------
  - Render Thread: Pushes frames to your graphics card (GPU).
  - Physics Thread: Calculates gravity, collisions, and car crashes.
  - Audio Thread: Processes spatial 3D sound effects and background music.
 
  3. IDEs and Text Editors (Visual Studio, VS Code)
  ----------------------------------------------------------------------------
  - Foreground Thread: Keeps the typing cursor smooth and responsive.
  - Background Threads: Continuously compile your C# code, run IntelliSense 
    code suggestions, and analyze git changes.
 
  4. Media Players (VLC, YouTube App)
  ----------------------------------------------------------------------------
  - Thread A: Buffers and downloads the next 30 seconds of video chunks.
  - Thread B: Decodes the raw video frames and displays them on screen.
  - Thread C: Syncs the audio track perfectly with the video timestamps.
 */