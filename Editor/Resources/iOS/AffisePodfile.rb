platform :ios, '11.0'

target 'UnityFramework' do
   pod 'AffiseInternal', '1.6.14'

   # Affise Modules
   # pod 'AffiseModule', '1.6.14'
end

target 'Unity-iPhone' do
end

use_frameworks! :linkage => :static
