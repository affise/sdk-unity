platform :ios, '11.0'

target 'UnityFramework' do
   pod 'AffiseInternal', '1.6.18'

   # Affise Modules
   # pod 'AffiseModule/Advertising', '1.6.18'
   # pod 'AffiseModule/Status', '1.6.18'
end

target 'Unity-iPhone' do
end

use_frameworks! :linkage => :static
